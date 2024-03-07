using System;
using CConsalud.Model.Responses;
using Consalud.Commons.contracts;
using Consalud.Commons.Helpers;
using Consalud.DataAccess;
using Consalud.Model.Requests;
using ConsaludApiRest.Jwt;

namespace ConsaludApiRest.Services
{
	public class UserServices : IUserServices
    {
		private IJwtService jwt;

		private IUserRepository userRepository;
        public UserServices(IJwtService jwtService, IConfiguration conf)
		{
			this.jwt = jwtService;

			userRepository = new DatabaseEngine(conf).UserRepository;
		}

		public AuthResponse CreateUser(AuthRequest request)
		{
	
			var result = userRepository.CreateUser(request.Username, request.Password);

			if (result)
			{
				var token = jwt.GetToken(request.Username);
				return new AuthResponse() { UserName = request.Username, Token = token };
			}

			return null;
		}

        public AuthResponse LoginUser(AuthRequest request)
        {

			var result = userRepository.GetUserByUsername(request.Username);
			AuthResponse response = null;

			if(result == null)
			{
				return null;
			}

            if (result.Password == CustomHelper.EncryptPassword(request.Password))
            {
                var token = jwt.GetToken(request.Username);
                return new AuthResponse() { UserName = request.Username, Token = token };
            }
			else
			{
                return new AuthResponse() { UserName = request.Username, Token = string.Empty };
            }
			
            
        }
    }
}


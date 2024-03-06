using System;
using CConsalud.Model.Responses;
using Consalud.Commons.contracts;
using Consalud.Model.Requests;
using ConsaludApiRest.Data;
using ConsaludApiRest.Helpers;
using ConsaludApiRest.Jwt;

namespace ConsaludApiRest.Services
{
	public class UserServices : IUserServices
    {
		private IJwtService jwt;
     
        UserDA uDa;
        public UserServices(IJwtService jwtService, IConfiguration conf)
		{
			this.jwt = jwtService;
     
            uDa = new UserDA(conf);
		}

		public AuthResponse CreateUser(AuthRequest request)
		{
	
			var result = uDa.CreateUser(request.Username, request.Password);

			if (result)
			{
				var token = jwt.GetToken(request.Username);
				return new AuthResponse() { UserName = request.Username, Token = token };
			}

			return null;
		}

        public AuthResponse LoginUser(AuthRequest request)
        {

			var result = uDa.GetUserByUsername(request.Username);
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


using System;
using ConsaludApiRest.Data;
using ConsaludApiRest.Helpers;
using ConsaludApiRest.Jwt;
using ConsaludApiRest.Mappers;

namespace ConsaludApiRest.Services
{
	public class UserServices
	{
		private IJwtService jwt;
		public UserServices(IJwtService jwtService)
		{
			this.jwt = jwtService;
		}

		public AuthResponse CreateUser(AuthRequest request)
		{
			UserDA uDa = new UserDA();
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
            UserDA uDa = new UserDA();
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


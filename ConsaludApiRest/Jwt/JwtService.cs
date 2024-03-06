using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ConsaludApiRest.Jwt
{
	public class JwtService : IJwtService
	{
		public IConfiguration configuration;

		public JwtService(IConfiguration pConfiguration)
		{
			this.configuration = pConfiguration;
		}

		public string GetToken(string userName)
		{
			var claims = new[]
			{
				new Claim("userName", userName)
			};

			var key = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:SecretKey").Get<String>() ?? string.Empty));

			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				issuer: "MelaraGalaz",
				audience: "Public",
				claims: claims,
				expires: DateTime.Now.AddMinutes(45),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}


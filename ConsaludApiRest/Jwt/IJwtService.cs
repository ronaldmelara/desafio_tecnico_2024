using System;
namespace ConsaludApiRest.Jwt
{
	public interface IJwtService
	{
         string GetToken(string userName);

    }
}


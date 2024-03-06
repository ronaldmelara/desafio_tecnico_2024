using System;
namespace ConsaludApiRest.Mappers
{
	public class AuthRequest
	{
		public AuthRequest()
		{
		}

        public string Username { get; set; }
        public string Password { get; set; }
    }
}


using System;
namespace Consalud.Model.Requests
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


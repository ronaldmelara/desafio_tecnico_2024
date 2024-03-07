using System;
using System.ComponentModel.DataAnnotations;


namespace Consalud.Model.Entities
{
	
	public class Users
	{
		[Key]
		public string Username { get; set; }
		public string Password { get; set; }
	}
}


using System;
using Consalud.Model.Entities;

namespace Consalud.Commons.contracts
{
	public interface IUserRepository
	{
        public bool CreateUser(string username, string password);
        public Users GetUserByUsername(string username);
        public List<Users> GetUsers();
    }
}


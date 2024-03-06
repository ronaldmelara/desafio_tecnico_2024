using System;
using System.Text.Json;
using ConsaludApiRest.Helpers;
using ConsaludApiRest.Model;

namespace ConsaludApiRest.Data
{
	public class UserDA
	{
		private const string UsersFilePath = "users.json";
		public UserDA()
		{
		}

		public List<User> GetUsers()
		{
			
			string userJson = File.ReadAllText(UsersFilePath);
			return JsonSerializer.Deserialize<List<User>>(userJson);
		}

		public bool CreateUser(string username, string password)
		{
			try
			{
				string hashedPassword = CustomHelper.EncryptPassword(password);

				List<User> users;
				if (CustomHelper.CheckFile(UsersFilePath))
				{
					users = GetUsers();
				}
				else
				{
					users = new List<User>();
				}

				if(users.Exists(u=> u.Username == username))
				{
					return false;
				}

				users.Add(new User { Username = username, Password = hashedPassword });

				string userJsonUpdated = JsonSerializer.Serialize(users);
				CustomHelper.saveFile(userJsonUpdated, UsersFilePath);

				return true;
			}catch(Exception ex)
			{
				return false;
			}
		}

        public User GetUserByUsername(string username)
        {

            List<User> users = GetUsers();

            return users.FirstOrDefault(u=> u.Username == username);

        }
    }
}


using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsaludApiRest.Helpers
{
	public static class CustomHelper
	{

        public static string EncryptPassword(string password)
		{
			using(var sha256 = SHA256.Create())
			{
				var hashedByte = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
				return BitConverter.ToString(hashedByte).Replace("-", "").ToLower();
			}
		}

        

        public static string ReadJsonFile(string path)
		{
			return File.ReadAllText(path);
        }

		public static bool CheckFile(string path)
		{
			return File.Exists(path);
		}

		public static void saveFile(string json, string path)
		{
			File.WriteAllText(path, json);
		}
	}
}


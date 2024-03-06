using System;
using System.Text.Json;
using Consalud.DataAccess;
using Consalud.Model.Entities;
using ConsaludApiRest.Helpers;

namespace ConsaludApiRest.Data
{
	public class UserDA
	{

		private DatabaseEngine db;
		FacturasDA fa;
        public UserDA(IConfiguration conf)
		{
			db = new DatabaseEngine(conf);
			fa = new FacturasDA(conf);
        }

		public List<Users> GetUsers()
		{

			return db.Data.Users.ToList();
			//string userJson = File.ReadAllText(UsersFilePath);
			//return JsonSerializer.Deserialize<List<Users>>(userJson);
		}

		public bool CreateUser(string username, string password)
		{
			try
			{
				string hashedPassword = CustomHelper.EncryptPassword(password);

				List<Users> users = GetUsers();
                

				if(users.Exists(u=> u.Username == username))
				{
					return false;
				}

				users.Add(new Users { Username = username, Password = hashedPassword });
				db.Data.Users.Add(new Users { Username = username, Password = hashedPassword });
				db.Data.SaveChanges();


				return true;
			}catch(Exception ex)
			{
				return false;
			}
		}

        public Users GetUserByUsername(string username)
        {

            List<Users> users = GetUsers();


			//        var jsonString = File.ReadAllText("JsonEjemplo.json");
			//        var facturas = JsonSerializer.Deserialize<List<Facturas>>(jsonString);



			//            foreach (var factura in facturas)
			//            {
			//                db.Data.Facturas.Add(factura);

			//	foreach (var detalleFactura in factura.DetalleFactura)
			//	{
			//		// Guarda el detalle de la factura en la base de datos
			//		db.Data.DetalleFactura.Add(detalleFactura);

			//		// Guarda el producto asociado con el detalle de la factura en la base de datos
			//		db.Data.Producto.Add(detalleFactura.Producto);
			//	}
			//}
			//            db.Data.SaveChanges();


			var a = fa.GetFacturasPorRut(21595854);
            

            return users.FirstOrDefault(u=> u.Username == username);

        }
    }
}


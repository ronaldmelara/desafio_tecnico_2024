using System;
using Consalud.Commons.contracts;
using Consalud.Commons.Helpers;
using Consalud.Model.Entities;

namespace Consalud.DataAccess.Repositories
{
	public class UserDA : IUserRepository
    {
        private DataContext Data { set; get; }

        public UserDA(DataContext dataContext)
		{
            this.Data = dataContext;
        }

        public List<Users> GetUsers()
        {

            return Data.Users.ToList();
        }

        public bool CreateUser(string username, string password)
        {
            try
            {
                string hashedPassword = CustomHelper.EncryptPassword(password);

                List<Users> users = GetUsers();


                if (users.Exists(u => u.Username == username))
                {
                    return false;
                }

                users.Add(new Users { Username = username, Password = hashedPassword });
                Data.Users.Add(new Users { Username = username, Password = hashedPassword });
                Data.SaveChanges();


                return true;
            }
            catch (Exception ex)
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


            return users.FirstOrDefault(u => u.Username == username);

        }
    }
}


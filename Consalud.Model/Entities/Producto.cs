using System;
namespace Consalud.Model.Entities
{
	public class Producto
	{
		public Producto()
		{
		}
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Valor { get; set; }
    }
}


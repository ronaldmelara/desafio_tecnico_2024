using System;
namespace Consalud.Model.Entities
{
	public class DetalleFactura
	{
		public DetalleFactura()
		{
            this.Producto = new Producto();
		}
        public int Id { get; set; }
        public double CantidadProducto { get; set; }
        public Producto Producto { get; set; }
        public double TotalProducto { get; set; }
    }
}


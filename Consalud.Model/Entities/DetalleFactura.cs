using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consalud.Model.Entities
{
	public class DetalleFactura

	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double CantidadProducto { get; set; }

        [ForeignKey("Facturas")]
        public int FacturaId { get; set; }

        public virtual Facturas Facturas { get; set; }

  
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public double TotalProducto { get; set; }
    }
}


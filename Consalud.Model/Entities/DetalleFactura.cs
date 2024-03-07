using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Consalud.Model.Entities
{
	public class DetalleFactura

	{
        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double CantidadProducto { get; set; }

        [JsonIgnore]
        [ForeignKey("Facturas")]
        public int FacturaId { get; set; }
        [JsonIgnore]
        public virtual Facturas Facturas { get; set; }

        [JsonIgnore]
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }

        public double TotalProducto { get; set; }
    }
}


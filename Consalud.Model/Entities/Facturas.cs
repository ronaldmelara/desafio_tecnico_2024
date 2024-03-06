using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Consalud.Model.Entities
{
	public class Facturas
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double NumeroDocumento { get; set; }
        public double RUTVendedor { get; set; }
        public string DvVendedor { get; set; }
        public double RUTComprador { get; set; }
        public string DvComprador { get; set; }
        public string DireccionComprador { get; set; }
        public double ComunaComprador { get; set; }
        public double RegionComprador { get; set; }
        public double TotalFactura { get; set; }
        public virtual List<DetalleFactura> DetalleFactura { get; set; }
    }
}


using System;
using Consalud.Model.Entities;

namespace Consalud.Model.Responses
{
	public class FacturaTotalResponse
	{
		public Facturas Factura { get; set; }
		public double TotalFactura { get; set; }
	}
}


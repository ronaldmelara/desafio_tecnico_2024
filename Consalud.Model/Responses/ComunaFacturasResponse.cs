using System;
using Consalud.Model.Entities;

namespace Consalud.Model.Responses
{
	public class ComunaFacturasResponse
	{
        public double Comuna { get; set; }
        public List<Facturas> Facturas { get; set; }
    }
}


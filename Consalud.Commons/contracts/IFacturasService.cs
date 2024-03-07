using System;
using Consalud.Model.Entities;
using Consalud.Model.Responses;

namespace Consalud.Commons.contracts
{
	public interface IFacturasService
	{
        public List<Facturas> GetFacturasPorRut(int rut);
        public List<FacturaTotalResponse> GetFacturas();
        public ClienteFrecuenteResponse GetCompradorConMasCompras();
        public List<ClienteFrecuenteResponse> GetTotalCompraPorComprador();
        public List<ComunaFacturasResponse> GetFacturasAgrupadasPorComuna();
        public ComunaFacturasResponse GetFacturasPorComuna(double idComuna);
    }
}


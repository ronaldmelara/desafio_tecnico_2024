using System;
using Consalud.Commons.contracts;
using Consalud.DataAccess;
using Consalud.Model.Entities;
using Consalud.Model.Responses;

namespace ConsaludApiRest.Services
{
	public class FacturasServices : IFacturasService
	{
		IFacturasRepository repository;
		public FacturasServices(IConfiguration conf)
		{

			repository = new DatabaseEngine(conf).FacturasRepository;
		}


        public List<Facturas> GetFacturasPorRut(int rut)
        {
            return repository.GetFacturasPorRut(rut);

        }

        public List<FacturaTotalResponse> GetFacturas()
        {
            return repository.GetFacturas();

        }


        public ClienteFrecuenteResponse GetCompradorConMasCompras()
        {
            return repository.GetCompradorConMasCompras();

        }

        public List<ClienteFrecuenteResponse> GetTotalCompraPorComprador()
        {
            return repository.GetTotalCompraPorComprador();

        }



        public List<ComunaFacturasResponse> GetFacturasAgrupadasPorComuna()
        {
            return repository.GetFacturasAgrupadasPorComuna();

        }

        public ComunaFacturasResponse GetFacturasPorComuna(double idComuna)
        {

            return repository.GetFacturasPorComuna(idComuna);
        }
    }
}


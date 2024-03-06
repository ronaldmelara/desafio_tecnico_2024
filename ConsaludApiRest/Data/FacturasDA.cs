using System;
using Consalud.DataAccess;
using Consalud.Model.Entities;
using Consalud.Model.Responses;

namespace ConsaludApiRest.Data
{
	public class FacturasDA
	{
        private DatabaseEngine db;
        public FacturasDA(IConfiguration conf)
		{
            db = new DatabaseEngine(conf);
        }

        public List<Facturas> GetFacturasPorRut(int rut)
        {
            var lst = db.Data.Facturas.Where(f => f.RUTComprador == rut)?.ToList();
            return lst;
           
        }

        public List<FacturaTotalResponse> GetFacturas()
        {
            var lst = db.Data.Facturas.ToList();
            List< FacturaTotalResponse> facturasConTotal = lst.Select(factura => new FacturaTotalResponse
            {
                Factura = factura,
                TotalFactura = factura.DetalleFactura.Sum(det => det.TotalProducto)
            }).ToList();

            return facturasConTotal;

        }


        public CompradorCompraResponse GetCompradorConMasCompras()
        {
            var lst = db.Data.Facturas.ToList();
            CompradorCompraResponse facturasConTotal = lst.GroupBy(f => new { f.RUTComprador, f.DvComprador })
                .Select(g => new CompradorCompraResponse
                {
                    RutComprador = g.Key.RUTComprador,
                    DvComprador = g.Key.DvComprador,
                    TotalCompras = g.Sum(f => f.DetalleFactura.Sum(det => det.TotalProducto))
                })
                .OrderByDescending(g=> g.TotalCompras)
                .FirstOrDefault();

            return facturasConTotal;

        }

        public List<CompradorCompraResponse> GetTotalCompraPorComprador()
        {
            var lst = db.Data.Facturas.ToList();
            List<CompradorCompraResponse> facturasComprador = lst.GroupBy(f => new { f.RUTComprador, f.DvComprador })
                .Select(g => new CompradorCompraResponse
                {
                    RutComprador = g.Key.RUTComprador,
                    DvComprador = g.Key.DvComprador,
                    TotalCompras = g.Sum(f => f.DetalleFactura.Sum(det => det.TotalProducto))
                }).ToList();
              

            return facturasComprador;

        }



        public List<ComunaFacturasResponse> GetFacturasAgrupadasPorComuna()
        {
            var lst = db.Data.Facturas.ToList();
            List<ComunaFacturasResponse> facturasComuna = lst.GroupBy(f => f.ComunaComprador)
                .Select(g => new ComunaFacturasResponse
                {
                    Comuna = g.Key,
                    Facturas = g.ToList()
                }).ToList();


            return facturasComuna;

        }

        public ComunaFacturasResponse GetFacturasPorComuna(double idComuna)
        {
            
            var comunas = GetFacturasAgrupadasPorComuna();
            return comunas.FirstOrDefault(c => c.Comuna == idComuna);



        }

    }
}


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


        public CompradorMasCompraResponse GetCompradorConMasCompras()
        {
            var lst = db.Data.Facturas.ToList();
            CompradorMasCompraResponse facturasConTotal = lst.GroupBy(f => new { f.RUTComprador, f.DvComprador })
                .Select(g => new CompradorMasCompraResponse
                {
                    RutComprador = g.Key.RUTComprador,
                    DvComprador = g.Key.DvComprador,
                    TotalCompras = g.Sum(f => f.DetalleFactura.Sum(det => det.TotalProducto))
                })
                .OrderByDescending(g=> g.TotalCompras)
                .FirstOrDefault();

            return facturasConTotal;

        }

    }
}


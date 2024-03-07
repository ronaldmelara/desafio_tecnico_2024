using System;
using Consalud.Commons.contracts;
using Consalud.Model.Entities;
using Consalud.Model.Responses;
using Microsoft.EntityFrameworkCore;

namespace Consalud.DataAccess.Repositories
{
	public class FacturasDA : IFacturasRepository
    {

        private DataContext Data { set; get; }

        public FacturasDA(DataContext dataContext)
		{
            this.Data = dataContext;
        }

        public List<Facturas> GetFacturasPorRut(int rut)
        {
            var lst = Data.Facturas.Where(f => f.RUTComprador == rut)?.ToList();
            lst?.ForEach(o =>
            {
                o.TotalFactura = o.DetalleFactura.Sum(det => det.TotalProducto);
            });
            return lst;
           
        }

        public List<FacturaTotalResponse> GetFacturas()
        {
            var lst = GetFacturasTodas();

            lst.ForEach(o => {
                o.TotalFactura = o.DetalleFactura.Sum(det => det.TotalProducto);
            });


            List<FacturaTotalResponse> facturasConTotal = lst.Select(factura =>
            new FacturaTotalResponse
            {
                Factura = factura,
                TotalFactura = factura.TotalFactura
            }).ToList();

            return facturasConTotal;

        }


        public ClienteFrecuenteResponse GetCompradorConMasCompras()
        {
            var lst = GetFacturasTodas();
            ClienteFrecuenteResponse facturasConTotal = lst.GroupBy(f => new { f.RUTComprador, f.DvComprador })
                .Select(g => new ClienteFrecuenteResponse
                {
                    RutComprador = g.Key.RUTComprador,
                    DvComprador = g.Key.DvComprador,
                    TotalCompras = g.Sum(f => f.DetalleFactura.Sum(det => det.TotalProducto))
                })
                .OrderByDescending(g=> g.TotalCompras)
                .FirstOrDefault();

            return facturasConTotal;

        }

        public List<ClienteFrecuenteResponse> GetTotalCompraPorComprador()
        {
            var lst = GetFacturasTodas();
            List<ClienteFrecuenteResponse> facturasComprador = lst.GroupBy(f => new { f.RUTComprador, f.DvComprador })
                .Select(g => new ClienteFrecuenteResponse
                {
                    RutComprador = g.Key.RUTComprador,
                    DvComprador = g.Key.DvComprador,
                    TotalCompras = g.Sum(f => f.DetalleFactura.Sum(det => det.TotalProducto))
                }).ToList();
              

            return facturasComprador;

        }



        public List<ComunaFacturasResponse> GetFacturasAgrupadasPorComuna()
        {
            var lst = GetFacturasTodas();
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

        private List<Facturas> GetFacturasTodas()
        {
            return Data.Facturas.Include(factura => factura.DetalleFactura).ThenInclude(detalle => detalle.Producto).ToList(); 
        }

    }
}


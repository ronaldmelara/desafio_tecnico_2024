using System;
using Consalud.Commons.contracts;
using ConsaludApiRest.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ConsaludApiRest.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class FacturasController : ControllerBase
    {
        private IFacturasService pFacturasService;
        public FacturasController(IFacturasService facturasService)
		{
            this.pFacturasService = facturasService;

		}


        [HttpGet("facturas")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "facturas", Summary = "Lista de facturas", Description = "Retornar lista completa de las facturas y calcular el total de cada una de ellas.")]
        public IActionResult GetFacturas()
        {
            try
            {
                var facturas = pFacturasService.GetFacturas();
                if (facturas == null)
                {
                    return NotFound();
                }
                return Ok(facturas);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno al obtener el listado de facturas");
            }
            
        }


        [HttpGet("facturas/{rut}")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "facturas", Summary = "Lista de facturas por rut", Description = "Retornar las facturas de un comprador según su rut.")]
        public IActionResult GetFacturasPorRut(int rut)
        {
            try
            {
                var facturas = pFacturasService.GetFacturasPorRut(rut);
                if (facturas == null)
                {
                    return NotFound();
                }
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno al obtener el listado de facturas para el RUT {rut}");
            }

        }


        [HttpGet("facturas/clientes/frecuente")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "cliente-frecuente", Summary = "Comprador con mas compras (cliente frecuente)", Description = "Retornar el comprador que tenga mas compras.")]
        public IActionResult GetClienteFrecuente()
        {
            try
            {
                var cliente = pFacturasService.GetCompradorConMasCompras();
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno al obtener la información del cliente frecuente");
            }

        }

        [HttpGet("facturas/clientes")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "cliente-compras", Summary = "Clientes y compras realizadas", Description = "Retornar lista de compradores con el monto total de compras realizadas.")]
        public IActionResult GetClientesCompras()
        {
            try
            {
                var clientes = pFacturasService.GetTotalCompraPorComprador();
                if (clientes == null)
                {
                    return NotFound();
                }
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno al obtener la información de la lista de clientes con sus totalizaciones");
            }

        }


        [HttpGet("facturas/comuna/{idComuna}")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "facturas-comuna", Summary = "Facturas por Comuna específica", Description = "Retornar lista de facturas agrupadas por comuna especifica.")]
        public IActionResult GetFacturasPorComuna(int idComuna)
        {
            try
            {
                var facturas = pFacturasService.GetFacturasPorComuna(idComuna);
                if (facturas == null)
                {
                    return NotFound();
                }
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Se produjo un error interno al obtener la información de la lista de facturas para la comuna Id {idComuna}");
            }

        }


        [HttpGet("facturas/comuna")]
        [Authorize]
        [TokenAuthorizationFilter]
        [SwaggerOperation(OperationId = "facturas-comuna", Summary = "Facturas agrupada por Comuna", Description = "Retornar lista de facturas agrupadas por comuna.")]
        public IActionResult GetFacturasGrupoComuna()
        {
            try
            {
                var facturas = pFacturasService.GetFacturasAgrupadasPorComuna();
                if (facturas == null)
                {
                    return NotFound();
                }
                return Ok(facturas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Se produjo un error interno al obtener la información de la lista facturas agrupadas por comuna");
            }

        }

    }
}


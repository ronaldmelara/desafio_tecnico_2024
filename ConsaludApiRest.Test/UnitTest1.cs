using Consalud.Commons.contracts;
using Consalud.Model.Entities;
using ConsaludApiRest.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Consalud.Model.Responses;

namespace ConsaludApiRest.Test;

public class Tests
{


    [Test]
    public void GetFacturas_Returns_OkResult_When_FacturasExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetFacturas())
            .Returns(new List<FacturaTotalResponse>());

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetFacturas();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }


    [Test]
    public void GetFacturasPorRut_Returns_NotFoundResult_When_FacturasDoNotExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetFacturasPorRut(It.IsAny<int>()))
            .Returns((List<Facturas>)null);

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetFacturasPorRut(123456);

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }


    [Test]
    public void GetClienteFrecuente_Returns_OkResult_When_FacturasExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetCompradorConMasCompras())
            .Returns(new ClienteFrecuenteResponse());

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetClienteFrecuente();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public void GetClientesCompras_Returns_OkResult_When_FacturasExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetTotalCompraPorComprador())
            .Returns(new List<ClienteFrecuenteResponse>());

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetClientesCompras();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }

    [Test]
    public void GetFacturasPorComuna_Returns_NotFoundResult_When_FacturasDoNotExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetFacturasPorComuna(It.IsAny<int>()))
            .Returns((ComunaFacturasResponse)null);

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetFacturasPorComuna(0);

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public void GetFacturasGrupoComuna_Returns_OkResult_When_FacturasExist()
    {
        // Arrange
        var mockFacturasService = new Mock<IFacturasService>();
        mockFacturasService.Setup(service => service.GetFacturasAgrupadasPorComuna())
            .Returns(new List<ComunaFacturasResponse>());

        var controller = new FacturasController(mockFacturasService.Object);

        // Act
        var result = controller.GetFacturasGrupoComuna();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
    }
}

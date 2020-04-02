using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Test
{
    public class CDTTests
    {
        BancoContext _context;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;

            _context = new BancoContext(optionsInMemory);
        }

        [Test]
        public void CrearDeposito()
        {
            //Creacion
            /*var createRequest = new CrearDepositoRequest { Numero = "", Nombre = ""};
            CrearDepositoService _createService = new CrearDepositoService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se creó con exito la cuenta 1113.", createResponse.Mensaje);*/
        }

    }
}

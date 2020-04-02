using Infrastructure;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Application.Test
{
    public class CuentasBancariasTests
    {
        BancoContext _context;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase("Banco").Options;

            _context = new BancoContext(optionsInMemory);            
        }

        #region Tests Cuentas de Ahorro

        [Test]
        public void CrearCuentaAhorroTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10001", Nombre = "Cuenta ejemplo", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se creó con exito la cuenta 10001.", createResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaAhorroTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10001", Nombre = "Cuenta ejemplo", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            
            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "10001", Ciudad = "Cuenta ejemplo", Valor = 100000 };            
            var consignarResponse = _consignarService.Ejecutar(consignarRequest);
            Assert.AreEqual($"Su Nuevo saldo es {consignarRequest.Valor}.", consignarResponse.Mensaje);                        
        }

        [Test]
        public void RetirarCuentaAhorroTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10001", Nombre = "Cuenta ejemplo", TipoCuenta = "Ahorro" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
             _createService.Ejecutar(createRequest);

            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "10001", Ciudad = "Valledupar", Valor = 100000 };
            _consignarService.Ejecutar(consignarRequest);

            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "10001", Valor = 50000 };
            var retirarResponse = _retirarService.Ejecutar(retirarRequest);
            Assert.AreEqual($"Su Nuevo saldo es 50000.", retirarResponse.Mensaje);
        }

        #endregion

        #region Tests Cuentas Corrientes
        [Test]
        public void CrearCuentaCorrienteTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10002", Nombre = "Cuenta Ejemplo", TipoCuenta = "Corriente" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se creó con exito la cuenta 10002.", createResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaCorrienteTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10002", Nombre = "Cuenta Ejemplo", TipoCuenta = "Corriente" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            
            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "10002", Ciudad = "Valledupar", Valor = 100000 };
            var consignarResponse = _consignarService.Ejecutar(consignarRequest);
            Assert.AreEqual($"Su Nuevo saldo es {consignarRequest.Valor}.", consignarResponse.Mensaje);
        }

        [Test]
        public void RetirarCuentaCorrienteTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10002", Nombre = "Cuenta Ejemplo", TipoCuenta = "Corriente" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            _createService.Ejecutar(createRequest);

            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "10002", Ciudad = "Valledupar", Valor = 100000 };
            _consignarService.Ejecutar(consignarRequest);

            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "10002", Valor = 50000 };
            var retirarResponse = _retirarService.Ejecutar(retirarRequest);
            Assert.AreEqual($"Su Nuevo saldo es 49800.", retirarResponse.Mensaje);
        }

        #endregion

        #region Tests Cuentas de Credito

        [Test]
        public void CrearCuentaCreditoTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10003", Nombre = "Cuenta Ejemplo", TipoCuenta = "Credito" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);
            Assert.AreEqual("Se creó con exito la cuenta 10003.", createResponse.Mensaje);
        }

        [Test]
        public void RetirarCuentaCreditoTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10003", Nombre = "Cuenta Ejemplo", TipoCuenta = "Credito" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);

            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "10003", Valor = 300000 };
            var retirarResponse = _retirarService.Ejecutar(retirarRequest);
            Assert.AreEqual($"Su Nuevo saldo es 700000.", retirarResponse.Mensaje);
        }

        [Test]
        public void ConsignarCuentaCreditoTest()
        {
            var createRequest = new CrearCuentaBancariaRequest { Numero = "10003", Nombre = "Cuenta Ejemplo", TipoCuenta = "Credito" };
            CrearCuentaBancariaService _createService = new CrearCuentaBancariaService(new UnitOfWork(_context));
            var createResponse = _createService.Ejecutar(createRequest);

            RetirarService _retirarService = new RetirarService(new UnitOfWork(_context));
            var retirarRequest = new RetirarRequest { NumeroCuenta = "10003", Valor = 300000 };
            var retirarResponse = _retirarService.Ejecutar(retirarRequest);

            ConsignarService _consignarService = new ConsignarService(new UnitOfWork(_context));
            var consignarRequest = new ConsignarRequest { NumeroCuenta = "10003", Ciudad = "Valledupar", Valor = 200000 };
            var consignarResponse = _consignarService.Ejecutar(consignarRequest);
            Assert.AreEqual($"Su Nuevo saldo es 900000.", consignarResponse.Mensaje);
        }       

        #endregion
    }
}
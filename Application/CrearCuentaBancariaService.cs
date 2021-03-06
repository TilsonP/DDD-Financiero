﻿using Domain.Contracts;
using Domain.Entities;
using Domain.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class CrearCuentaBancariaService
    {
        readonly IUnitOfWork _unitOfWork;
        
        public CrearCuentaBancariaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CrearCuentaBancariaResponse Ejecutar(CrearCuentaBancariaRequest request)
        {
            CuentaBancaria cuentaNueva = null;
            CuentaBancaria cuenta = _unitOfWork.CuentaBancariaRepository.FindFirstOrDefault(t => t.Numero==request.Numero);
            if (cuenta == null)
            {
                cuentaNueva = new CuentaBancariaFactory().Create(request.TipoCuenta);
                cuentaNueva.Nombre = request.Nombre;
                cuentaNueva.Numero = request.Numero;
                _unitOfWork.CuentaBancariaRepository.Add(cuentaNueva);
                _unitOfWork.Commit();
                return new CrearCuentaBancariaResponse() { Mensaje = $"Se creó con exito la cuenta {cuentaNueva.Numero}.", TipoDeCuentaCreado = request.TipoCuenta };
            }
            else
            {
                return new CrearCuentaBancariaResponse() { Mensaje = $"El número de cuenta ya exite" };
            }
        }
    }
    public class CrearCuentaBancariaRequest
    {
        public string Nombre { get; set; }
        public string TipoCuenta { get; set; }
        public string Numero { get; set; }
    }
    public class CrearCuentaBancariaResponse
    {
        public string Mensaje { get; set; }
        public string TipoDeCuentaCreado { get; set; }
    }
}

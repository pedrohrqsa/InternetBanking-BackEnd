using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using System;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClientesController(IClienteRepositorio clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }
        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        [HttpGet("{cpf}", Name = "GetClientes")]
        public IActionResult GetByCPF(string cpf)
        {
            var cliente = _clienteRepositorio.FindByCpf(cpf);

            if (cliente == null) return NotFound();
            return new ObjectResult(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente, ContaCorrente cc, Conta c)
        {
            if (cliente == null) return BadRequest();

            // ContaCorrente cc = new ContaCorrente();

            if (cc.numeroConta == 0)
            {
                Random randNum = new Random();
                cc.numeroConta = (randNum.Next(1001, 9999));
            }

            _clienteRepositorio.AddCliente(cliente);
            return new ObjectResult(new ClienteLogin());
        }
    }
}

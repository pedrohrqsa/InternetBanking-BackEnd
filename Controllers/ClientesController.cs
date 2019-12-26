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
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();

            _clienteRepositorio.AddCliente(cliente);

            return new ObjectResult(new ClienteLogin());
        }

        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] Cliente cliente, string cpf)
        {
            if (cliente == null) return NotFound();

            var _cliente = _clienteRepositorio.FindByCpf(cpf);
            if(cliente.nome!=""){_cliente.nome = cliente.nome;}

            if(cliente.sobrenome!=""){_cliente.sobrenome = cliente.sobrenome;}
            // _cliente.cpf = cliente.cpf;
            if(cliente.rg!=""){ _cliente.rg = cliente.rg;}

            if(cliente.orgaoEmissor!= ""){_cliente.orgaoEmissor = cliente.orgaoEmissor;}
            
            if(cliente.dtNascimento!= null){_cliente.dtNascimento = cliente.dtNascimento;}

            if(cliente.nacionalidade!=""){_cliente.nacionalidade = cliente.nacionalidade;}

            if(cliente.naturalidade!=""){_cliente.naturalidade = cliente.naturalidade;}
    }
}

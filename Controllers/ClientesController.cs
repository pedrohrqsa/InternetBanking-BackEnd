using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;
namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    [Authorize()]
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
        public IActionResult GetById(string cpf)
        {
            var cliente = _clienteRepositorio.FindByCpf(cpf);

            if (cliente == null) return NotFound();
            return new ObjectResult(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente clientes)
        {
            if (clientes == null) return BadRequest();

            _clienteRepositorio.AddCliente(clientes);
            return new ObjectResult(_clienteRepositorio.FindByCpf(clientes.CPF)) ;
        }
    }
}
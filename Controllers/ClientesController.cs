using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;
namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    [Authorize()]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }

        [HttpGet]
        public IEnumerable<ClienteLogin> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        [HttpGet("{cpf}", Name = "GetLogin")]
        public IActionResult GetById(string cpf)
        {
            var cliente = _clienteRepositorio.FindByCpf(cpf);
            
            if (cliente == null) return NotFound();
            return new ObjectResult(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClienteCad clientes)
        {
            if (clientes == null) return BadRequest();

            _clienteRepositorio.Add(clientes);
            return CreatedAtRoute("GetCliente", new { id = clientes.ID_CLIENTE }, clientes);
        }
    }
}
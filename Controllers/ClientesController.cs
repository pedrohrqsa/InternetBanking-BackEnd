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

        [HttpGet("{id}", Name = "GetLogin")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepositorio.Find(id);
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
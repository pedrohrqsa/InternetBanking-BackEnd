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
        private readonly IClienteLoginRepositorio _clienteRepositorio;
        public ClienteController(IClienteLoginRepositorio clienteRepo)
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
        public IActionResult Create([FromBody] ClienteLogin clientes)
        {
            if (clientes == null) return BadRequest();

            _clienteRepositorio.AddClienteLogin(clientes);
            return CreatedAtRoute("GetCliente", new { id = clientes.Id_login }, clientes);
        }
    }
}
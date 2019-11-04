using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositorio;
namespace test.Controllers
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
        public IEnumerable<Cliente> GetAll()
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
    }
}
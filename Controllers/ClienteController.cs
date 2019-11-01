using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using test.Models;
using test.Repositorio;
namespace test.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteController(IClienteRepositorio ClienteRep)
        {
            _clienteRepositorio = ClienteRep;
        }
        [HttpPost]
        public IActionResult Create ([FromBody] Cliente Cli){
            if (Cli == null) return BadRequest();

            _clienteRepositorio.Add(Cli);
            return CreatedAtRoute("GetCliente", new {id=Cli.ID_CLIENTE}, Cli);
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(long id)
        {
            var cliente = _clienteRepositorio.Find(id);
            if (cliente == null) return NotFound();

            return new ObjectResult(cliente);
        }
    }
}
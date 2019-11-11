using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;

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
    }
}




// return CreatedAtRoute("GetClientes", new {cpf=cliente.CPF}, cliente);
//  return new RedirectToActionResult("RequestToken", "Token", cliente.clienteLogin.FirstOrDefault());

//   return  RedirectToAction("RequestToken","Token",cliente.clienteLogin.FirstOrDefault());

//   return  RedirectToAction("RequestToken","Token",cliente.clienteLogin.FirstOrDefault());

// return RedirectToAction("requestToken", "API/TOKEN", cliente.clienteLogin.FirstOrDefault());
// return RedirectToAction("api/token");

// return new ObjectResult(new TokenController(token));
// return CreatedAtRoute("api/token", ());
// ("GetAll", "ControllerName",
//  return new ObjectResult( new TokenController(Ok));
// return new ObjectResult(new TokenController());

// [HttpGet("{id}", Name = "GetIdClientes")]
// public IActionResult GetByIdClientes(int id)
// {
//     var cliente = _clienteRepositorio.FindByIdCliente(id);

//     if (cliente == null) return NotFound();
//     return new ObjectResult(cliente.CPF);
// }
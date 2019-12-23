using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;
namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ClienteLoginController : Controller
    {
        private readonly IClienteLoginRepositorio _clienteLoginRepositorio;
        public ClienteLoginController(IClienteLoginRepositorio clienteRepo)
        {
            _clienteLoginRepositorio = clienteRepo;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ClienteLogin Login)
        {
            if (Login == null) return BadRequest();
            _clienteLoginRepositorio.AddClienteLogin(Login);
            return new ObjectResult(new Conta());
        }

        [HttpGet]
        public IEnumerable<ClienteLogin> GetAll()
        {
            return _clienteLoginRepositorio.GetAll();
        }

        [HttpGet("{cpf}", Name = "GetLogin")]
        public IActionResult GetByLogin(string cpf)
        {
            var clienteLogin = _clienteLoginRepositorio.FindByCpf(cpf);

            if (clienteLogin == null) return NotFound();
            return new ObjectResult(clienteLogin);
        }
        
        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] ClienteLogin clienteLogin, string cpf)
        {
            if (clienteLogin == null) return NotFound();

            var _clienteLogin = _clienteLoginRepositorio.FindByCpf(cpf);
            
            _clienteLogin.senha = clienteLogin.senha;

            _clienteLoginRepositorio.Update(_clienteLogin);
            return new NoContentResult();
        }
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    [Authorize()]
    public class EnderecosController : Controller
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public EnderecosController(IEnderecoRepositorio enderecoRepo)
        {
            _enderecoRepositorio = enderecoRepo;
        }

        [HttpGet]
        public IEnumerable<Endereco> GetAll()
        {
            return _enderecoRepositorio.GetAll();
        }

        [HttpGet("{cep}", Name = "GetEndereco")]
        public IActionResult GetById(string cep)
        {
            var endereco = _enderecoRepositorio.FindByEnd(cep);
            if (endereco == null) return NotFound();
            return new ObjectResult(endereco);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Endereco endereco)
        {
            if (endereco == null) return BadRequest();
            _enderecoRepositorio.AddEndereco(endereco);
            return new ObjectResult(_enderecoRepositorio.FindByEnd(endereco.CEP));
        }
    }
}
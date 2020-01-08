using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
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
        public IActionResult GetById(int endereco)
        {
            var enderecos = _enderecoRepositorio.FindByEnd(endereco);
            if (enderecos == null) return NotFound();
            return new ObjectResult(endereco);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Endereco endereco)
        {
            if (endereco == null) return BadRequest();
            _enderecoRepositorio.AddEndereco(endereco);
            return new ObjectResult(_enderecoRepositorio.FindByEnd(endereco.idEndereco));
        }

        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] Endereco endereco, string cpf)
        {
            if (endereco == null) return NotFound();

            int idCliente = _enderecoRepositorio.FindByIdCliente(cpf);
            var _endereco = _enderecoRepositorio.FindByEnd(idCliente);
          
            _enderecoRepositorio.Update(endereco,_endereco);
            return new NoContentResult();
        }
    }
}
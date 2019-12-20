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

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] Endereco endereco)
        {
            if (endereco == null) return NotFound();

            var _endereco = _enderecoRepositorio.FindByEnd(endereco.idCliente);

            _endereco.logradouro = endereco.logradouro;
            _endereco.numero = endereco.numero;
            _endereco.complemento = endereco.complemento;
            _endereco.bairro = endereco.bairro;
            _endereco.cidade = endereco.cidade;
            _endereco.siglaEstado = endereco.siglaEstado;
            _endereco.cep = endereco.cep;
   
            _enderecoRepositorio.Update(_endereco);
            return new NoContentResult();
        }
    }
}
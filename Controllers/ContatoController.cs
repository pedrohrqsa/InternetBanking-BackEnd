using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRep;
        public ContatoController(IContatoRepositorio contatoRepo)
        {
            _contatoRep = contatoRepo;
        }

        [HttpGet]
        public IEnumerable<Contato> GetAll()
        {
            return _contatoRep.GetAll();
        }

        [HttpGet("{cont}", Name = "GetContato")]
        public IActionResult GetByCont(int id)
        {
            var contato = _contatoRep.FindByContato(id);

            if (contato == null) return NotFound();
            return new ObjectResult(contato);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Contato contatos)
        {
            if (contatos == null) return BadRequest();

            _contatoRep.AddContato(contatos);
            return new ObjectResult(_contatoRep.FindByContato(contatos.idCliente));
        }
    }
}
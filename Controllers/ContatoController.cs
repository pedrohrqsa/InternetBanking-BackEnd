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
        private readonly IClienteLoginRepositorio _clienteRepositorio;
        public ContatoController(IContatoRepositorio contatoRepo,
         IClienteLoginRepositorio clienteRepositorio)
        {
            _contatoRep = contatoRepo;
            _clienteRepositorio = clienteRepositorio;
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

        [HttpPut("{cpf}")]
        public IActionResult Update([FromBody] Contato contato, string cpf)
        {
            if (contato == null) return NotFound();

            int idCliente = _contatoRep.FindByIdCliente(cpf);
            var _contato = _contatoRep.FindByContato(idCliente);            
           
            _contatoRep.Update(contato,_contato);
            return new NoContentResult();
        }
    }
}
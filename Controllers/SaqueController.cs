using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class SaqueController : Controller
    {
        private readonly ISaqueRepositorio _saqueRepositorio;
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public SaqueController(ISaqueRepositorio saqueRepositorio)
        {
            _saqueRepositorio = saqueRepositorio;
        }

        [HttpGet]
        public IEnumerable<Saque> GetAll()
        {
            return _saqueRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetSaque")]
        public IActionResult GetById(int idSaque)
        {
            var saque = _saqueRepositorio.FindBySaque(idSaque);

            if (saque == null) return NotFound();
            
            return new ObjectResult(saque);
        }

        [HttpPut("{valor}")]
        public IActionResult Update(int idSaque, int idContaCorrente, [FromBody] Saque saque, [FromBody] ContaCorrente contaCorrente)
        {
            if (saque.valor <= 0 || contaCorrente.saldo < saque.valor || saque == null || contaCorrente == null || saque.idSaque != _idSaque || saque.valor < contaCorrente.saldo)
                return BadRequest();

            if (saque == null || contaCorrente == null)
                return NotFound();
            
            var _contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(idContaCorrente);

            _contaCorrente.saldo = contaCorrente.saldo;

            contaCorrente.saldo -= saque.valor;

            _contaCorrenteRepositorio.Update(_contaCorrente);
            return new NoContentResult();
        }
    }
}
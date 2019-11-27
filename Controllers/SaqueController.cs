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
        public IEnumerable<Deposito> GetAll()
        {
            return _saqueRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetSaque")]
        public IActionResult GetById(int idSaque)
        {
            var saque = _saqueRepositorio.FindByDeposito(idSaque);

            if (saque == null) return NotFound();
            
            return new ObjectResult(saque);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int _idSaque, int _idContaCorrente, [FromBody] Saque saque, [FromBody] ContaCorrente contaCorrente)
        {
            if(saque.valor <= 0 || contaCorrente.saldo < saque.valor)
                return false;
            contaCorrente.saldo -= saque.valor;
            return true;

            if (saque == null || contaCorrente == null || saque.idSaque != _idSaque || saque.valor < contaCorrente.saldo)
                return BadRequest();

            var _contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(_idContaCorrente);

            if (saque == null || contaCorrente == null)
                return NotFound();

            _contaCorrenteRepositorio.saldo = contaCorrente.saldo;

            _contaCorrenteRepositorio.Update(_deposito);
            return new NoContentResult();
        }
    }
}
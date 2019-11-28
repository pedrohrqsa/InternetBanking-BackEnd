using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        public ContaCorrenteController(IContaCorrenteRepositorio contaCorrenteRepositorio){
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        [HttpGet]
        public IEnumerable<ContaCorrente> GetAll()
        {
            return _contaCorrenteRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContaCorrente contaCorrente){
            if (contaCorrente == null) return BadRequest();
            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(contaCorrente.idContaCorrente));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int idDeposito, int idContaCorrente, [FromBody] Deposito deposito, [FromBody] ContaCorrente contaCorrente)
        {
            if (deposito.valor <= 0 || deposito == null || contaCorrente == null || deposito.idDeposito != _idDeposito || deposito.valor <= 0)
                return BadRequest();

            if (deposito == null || contaCorrente == null)
                return NotFound();

            _contaCorrente = FindByContaCorrente(contaCorrente);
            _contaCorrente.saldo += deposito.valor;

            var _contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(idContaCorrente);

            _contaCorrente.saldo = contaCorrente.saldo;

            contaCorrente.saldo += deposito.valor;

            _contaCorrenteRepositorio.Update(_contaCorrente);
            return new NoContentResult();
        }

        [HttpPut("{id}")]
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
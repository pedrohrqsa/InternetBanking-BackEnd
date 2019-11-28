using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using InternetBanking.Models;
using InternetBanking.Repositorio;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class DepositoController : Controller
    {
        private readonly IDepositoRepositorio _depositoRepositorio;
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public DepositoController(IDepositoRepositorio depositoRepositorio)
        {
            _depositoRepositorio = depositoRepositorio;
        }

        [HttpGet]
        public IEnumerable<Deposito> GetAll()
        {
            return _depositoRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetDeposito")]
        public IActionResult GetById(int idDeposito)
        {
            var deposito = _depositoRepositorio.FindByDeposito(idDeposito);

            if (deposito == null) return NotFound();
            
            return new ObjectResult(deposito);
        }

        [HttpPut("{valor}")]
        public IActionResult Update(int idDeposito, int idContaCorrente, [FromBody] Deposito deposito, [FromBody] ContaCorrente contaCorrente)
        {
            if (deposito.valor <= 0 || deposito == null || contaCorrente == null || deposito.idDeposito != _idDeposito || deposito.valor <= 0)
                return BadRequest();

            if (deposito == null || contaCorrente == null)
                return NotFound();

            var _contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(idContaCorrente);

            _contaCorrente.saldo = contaCorrente.saldo;

            contaCorrente.saldo += deposito.valor;

            _contaCorrenteRepositorio.Update(_contaCorrente);
            return new NoContentResult();
        }
    }
}
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

        // [HttpPut("{id}")]
        // public IActionResult Update(int _idDeposito, int _idContaCorrente, [FromBody] Deposito deposito, [FromBody] ContaCorrente contaCorrente)
        // {
        //     if(deposito.valor <= 0)
        //         return false;
        //     contaCorrente.saldo += deposito.valor;
        //     return true;

        //     if (deposito == null || contaCorrente == null || deposito.idDeposito != _idDeposito || deposito.valor < contaCorrente.saldo)
        //         return BadRequest();

        //     var _contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(_idContaCorrente);

        //     if (deposito == null || contaCorrente == null)
        //         return NotFound();

        //     _contaCorrenteRepositorio.saldo = contaCorrente.saldo;

        //     _contaCorrenteRepositorio.Update(_deposito);
        //     return new NoContentResult();
        // }
    }
}
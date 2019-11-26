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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Deposito deposito, ContaCorrente contaCorrente)
        {
            if (deposito == null || deposito.idDeposito != id) return BadRequest();

            var _deposito = _depositoRepositorio.FindByDeposito(id);

            if (deposito == null) return NotFound();

            _contaCorrenteRepositorio.saldo = contaCorrente.saldo;

            _contaCorrenteRepositorio.Update(_deposito);
            return new NoContentResult();
        }
    }
}
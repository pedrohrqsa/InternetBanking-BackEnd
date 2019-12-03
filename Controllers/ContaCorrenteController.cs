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

        [HttpGet("{contaCorrente}", Name = "GetContaCorrente")]
        public IActionResult GetByContaCorrente(int id)
        {
            var contaCorrente = _contaCorrenteRepositorio.FindByContaCorrente(id);

            if (contaCorrente == null) return NotFound();
            return new ObjectResult(contaCorrente);
        }

        public void Deposito(decimal valor){
            _contaCorrenteRepositorio.FindByContaCorrente(0).saldo += valor;
        } 

        public void Saque(decimal valor){
            _contaCorrenteRepositorio.FindByContaCorrente(0).saldo -= valor;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContaCorrente contaCorrente){
            if (contaCorrente == null) return BadRequest();
            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(contaCorrente.idContaCorrente));
        }

    }
}
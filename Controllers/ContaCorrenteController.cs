using InternetBanking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using InternetBanking.Repositorio;
using System;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaCorrenteController : Controller
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public ContaCorrenteController(IContaCorrenteRepositorio contaCorrenteRepositorio,
            ITransacaoRepositorio transacaoRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
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
        public IActionResult Create([FromBody] ContaCorrente contaCorrente)
        {
            if (contaCorrente == null) return BadRequest();
            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(contaCorrente.idContaCorrente));
        }

        [HttpPost]
        public IActionResult Deposito(Transacao deposito)
        {
            try
            {
                bool depositoEfetuado = _transacaoRepositorio.Deposito(deposito);
                if (depositoEfetuado)
                {
                    _contaCorrenteRepositorio.Deposito(deposito.numConta, deposito.valor);
                }
                else
                {
                    return new ObjectResult("erro não identificado!!!");
                }

            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(deposito.numConta));
        }

        public void Saque(Transacao saque, int numConta, decimal valor)
        {
            _transacaoRepositorio.Saque(saque);
            _contaCorrenteRepositorio.Saque(numConta, valor);
        }
    }
}
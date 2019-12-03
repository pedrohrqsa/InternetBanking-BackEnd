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

<<<<<<< HEAD
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

=======
>>>>>>> 665801a89aeb3c0cb800d76892b720d139b14a34
        [HttpPost]
        public IActionResult Create([FromBody] ContaCorrente contaCorrente)
        {
            if (contaCorrente == null) return BadRequest();
            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrente(contaCorrente.idContaCorrente));
        }

        public void Deposito(Transacao deposito, int numConta, decimal valor)
        {
            _transacaoRepositorio.Deposito(deposito);
            _contaCorrenteRepositorio.Deposito(numConta, valor);
        }

        public void Saque(Transacao saque, int numConta, decimal valor)
        {
            _transacaoRepositorio.Saque(saque);
            _contaCorrenteRepositorio.Saque(numConta, valor);
        }
    }
}
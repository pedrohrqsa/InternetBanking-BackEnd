using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        
        public TransacaoController(ITransacaoRepositorio transacaoRepositorio,
            IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        [HttpGet]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao deposito)
        {
            if (deposito == null) return BadRequest();

            _contaCorrenteRepositorio.Deposito(deposito.idContaCorrente, deposito.numConta, deposito.valor);
            
            _transacaoRepositorio.Deposito(deposito);
            return new ObjectResult(_transacaoRepositorio.FindByID(deposito.idTransacao));
        }
    }
}
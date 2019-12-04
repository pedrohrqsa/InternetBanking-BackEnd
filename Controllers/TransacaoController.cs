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
        public IActionResult Create([FromBody] Transacao transacao)
        {
            if (transacao == null) return BadRequest();

            if(transacao.idTipoTransacao == 1)
            {
                _contaCorrenteRepositorio.Deposito(transacao.idContaCorrente, transacao.numConta, transacao.valor);
                _transacaoRepositorio.Deposito(transacao);
            }
            else if(transacao.idTipoTransacao == 2)
            {
                _contaCorrenteRepositorio.Saque(transacao.idContaCorrente, transacao.numConta, transacao.valor);
                _transacaoRepositorio.Saque(transacao);
            }
            
            return new ObjectResult(_transacaoRepositorio.FindByID(transacao.idTransacao));
        }
    }
}
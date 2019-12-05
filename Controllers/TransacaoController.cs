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
        private readonly IContaRepositorio _contaRepositorio;
        
        public TransacaoController(ITransacaoRepositorio transacaoRepositorio,
            IContaRepositorio contaRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
            _contaRepositorio = contaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Transacao> GetAll()
        {
            return _transacaoRepositorio.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao transacao)
        {
            if (transacao == null)
                return BadRequest();

            if(transacao.idTipoTransacao == 1)
            {
                _contaRepositorio.Deposito(transacao.idConta, transacao.numeroContaDestino, transacao.valor);
                _transacaoRepositorio.Deposito(transacao);
            }
            else if(transacao.idTipoTransacao == 2)
            {
                _contaRepositorio.Saque(transacao.idConta, transacao.numeroContaOrigem, transacao.valor);
                _transacaoRepositorio.Saque(transacao);
            }
            else if (transacao.idTipoTransacao == 3)
            {
                _contaRepositorio.Transferencia(transacao.idConta, transacao.numeroContaOrigem, transacao.numeroContaDestino, transacao.valor);
                _transacaoRepositorio.Transferencia(transacao);
            }
            return new ObjectResult(_transacaoRepositorio.FindByID(transacao.idTransacao));
        }
    }
}
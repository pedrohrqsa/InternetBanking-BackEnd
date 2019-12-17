using System;
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

        [HttpGet("{numeroConta}", Name = "GetTransacao")]
        public IEnumerable<Transacao> GetAll(int numeroConta)
        {
            return _transacaoRepositorio.GetAll(numeroConta);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao transacao)
        {
            if (transacao == null || transacao.valor <=0){
                return BadRequest();

            }
            if(transacao.idTipoTransacao == 1)
            {   
                transacao.dtTransacao = DateTime.Now;
                _contaRepositorio.Deposito(transacao.numeroConta, transacao.numeroContaDestino, transacao.valor);
                _transacaoRepositorio.Deposito(transacao);
            }
            else if(transacao.idTipoTransacao == 2)
            {
                transacao.dtTransacao = DateTime.Now;
                _contaRepositorio.Saque(transacao.numeroConta, transacao.numeroContaOrigem, transacao.valor);
                _transacaoRepositorio.Saque(transacao);
            }
            else if (transacao.idTipoTransacao == 3)
            {
                transacao.dtTransacao = DateTime.Now;
                _contaRepositorio.Transferencia(transacao.numeroConta, transacao.numeroContaOrigem, transacao.numeroContaDestino, transacao.valor);
                _transacaoRepositorio.Transferencia(transacao);
            }
            return new ObjectResult(_transacaoRepositorio.FindByID(transacao.idTransacao));
        }
    }
}
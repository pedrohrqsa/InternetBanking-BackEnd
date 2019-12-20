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

        [HttpGet("{cpf}", Name = "GetTransacao")]
        public IEnumerable<Transacao> GetAll(string cpf)
        {
            int numeroConta = _contaRepositorio.FindByNumC(cpf);
            return _transacaoRepositorio.GetAll(numeroConta);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transacao transacao)
        {
            var _conta = _contaRepositorio.FindByConta(transacao.numeroConta);

            if ((transacao.senhaTransacoes == _conta.senhaTransacoes))
            {
                if (transacao.idTipoTransacao == 1)
                {
                    transacao.dtTransacao = DateTime.Now.ToString("dd/MM/yyyy");
                    _contaRepositorio.Deposito(transacao.numeroConta, transacao.numeroContaDestino, transacao.valor);
                    _transacaoRepositorio.Deposito(transacao);
                }
                else if (transacao.idTipoTransacao == 2)
                {
                    transacao.dtTransacao = DateTime.Now.ToString("dd/MM/yyyy");
                    _contaRepositorio.Saque(transacao.numeroConta, transacao.numeroContaOrigem, transacao.valor);
                    _transacaoRepositorio.Saque(transacao);
                }
                else if (transacao.idTipoTransacao == 3)
                {
                    transacao.dtTransacao = DateTime.Now.ToString("dd/MM/yyyy");
                    _contaRepositorio.Transferencia(transacao.numeroConta, transacao.numeroContaOrigem, transacao.numeroContaDestino, transacao.valor);
                    _transacaoRepositorio.Transferencia(transacao);
                }
                return new ObjectResult(_transacaoRepositorio.FindByID(transacao.idTransacao));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
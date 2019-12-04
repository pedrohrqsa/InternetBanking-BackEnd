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
        public IActionResult GetByContaCorrente(int numeroContaOrigem)
        {
            var contaCorrente = _contaCorrenteRepositorio.FindByContaCorrenteOrigem(numeroContaOrigem);

            if (contaCorrente == null) return NotFound();

            return new ObjectResult(contaCorrente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContaCorrente contaCorrente)
        {
            if (contaCorrente == null) return BadRequest();

            _contaCorrenteRepositorio.AddContaCorrente(contaCorrente);

            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrenteOrigem(contaCorrente.idContaCorrente));
        }

        [HttpPost]
        public IActionResult Deposito(Transacao deposito)
        {
            try
            {
                bool depositoEfetuado = _transacaoRepositorio.Deposito(deposito);
                if (depositoEfetuado)
                {
                    _contaCorrenteRepositorio.Deposito(deposito.idContaCorrente, deposito.numeroContaDestino, deposito.valor);
                }
                else
                {
                    return new ObjectResult("Depósito não efetuado.");
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrenteDestino(deposito.numeroContaDestino));
        }

        [HttpPost]
        public IActionResult Saque(Transacao saque)
        {
            try
            {
                bool saqueEfetuado = _transacaoRepositorio.Saque(saque);
                if (saqueEfetuado)
                {
                    _contaCorrenteRepositorio.Saque(saque.idContaCorrente, saque.numeroContaOrigem, saque.valor);
                }
                else
                {
                    return new ObjectResult("Saque não efetuado.");
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrenteOrigem(saque.numeroContaOrigem));
        }

        [HttpPost]
        public IActionResult Transferencia(Transacao transferencia)
        {
            try
            {
                bool transferenciaEfetuada = _transacaoRepositorio.Transferencia(transferencia);
                if (transferenciaEfetuada)
                {
                    _contaCorrenteRepositorio.Transferencia(transferencia.idContaCorrente,
                        transferencia.numeroContaOrigem, transferencia.numeroContaDestino, transferencia.valor);
                }
                else
                {
                    return new ObjectResult("Transferência não efetuada.");
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
            return new ObjectResult(_contaCorrenteRepositorio.FindByContaCorrenteOrigem(transferencia.numeroContaOrigem));
        }
    }
}
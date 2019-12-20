using System;
using System.Collections.Generic;
using InternetBanking.Models;
using InternetBanking.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetBanking.Controllers
{
    [Route("api/[Controller]")]
    public class ContaController : Controller
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public ContaController(IContaRepositorio ContaRepositorio)
        {
            _contaRepositorio = ContaRepositorio;
        }

        [HttpGet]
        public IEnumerable<Conta> GetAll()
        {
            return _contaRepositorio.GetAll();
        }

        [HttpGet("{conta}", Name = "GetConta")]
        public IActionResult GetByCont(int numeroConta)
        {
            var conta = _contaRepositorio.FindByConta(numeroConta);

            if (conta == null) return NotFound();
            return new ObjectResult(conta);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Conta conta)
        {
            if (conta == null) return BadRequest();

            _contaRepositorio.AddConta(conta);
            return new ObjectResult(new Conta());
        }

        [HttpPut("{numeroConta}")]
        public IActionResult Update(int numeroConta, [FromBody] Conta conta)
        {
            if (conta == null || conta.numeroConta != numeroConta || numeroConta == 0)
                return BadRequest();
                
            var _conta = _contaRepositorio.FindByConta(numeroConta);

            bool contaVerificada = _contaRepositorio.VerifyAccount(_conta);

            try
            {
                if(contaVerificada)
                {
                    _conta.flagAtivo = conta.flagAtivo;
                    _contaRepositorio.Update(_conta);
                }
                else
                {
                    return new ObjectResult("Sua conta não poderá ser inativada.");
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e);
            }
            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Deposito(Transacao deposito)
        {
            try
            {
                bool depositoEfetuado = _transacaoRepositorio.Deposito(deposito);
                if (depositoEfetuado)
                {
                    _contaRepositorio.Deposito(deposito.numeroConta, deposito.numeroContaDestino, deposito.valor);
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
            return new ObjectResult(_contaRepositorio.FindByContaDestino(deposito.numeroContaDestino));
        }

        [HttpPost]
        public IActionResult Saque(Transacao saque)
        {
            try
            {
                bool saqueEfetuado = _transacaoRepositorio.Saque(saque);
                if (saqueEfetuado)
                {
                    _contaRepositorio.Saque(saque.numeroConta, saque.numeroContaOrigem, saque.valor);
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
            return new ObjectResult(_contaRepositorio.FindByContaOrigem(saque.numeroContaOrigem));
        }

        [HttpPost]
        public IActionResult Transferencia(Transacao transferencia)
        {
            try
            {
                bool transferenciaEfetuada = _transacaoRepositorio.Transferencia(transferencia);
                if (transferenciaEfetuada)
                {
                    _contaRepositorio.Transferencia(transferencia.numeroConta,
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
            return new ObjectResult(_contaRepositorio.FindByContaOrigem(transferencia.numeroContaOrigem));
        }
    }
}
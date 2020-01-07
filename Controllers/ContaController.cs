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
        private readonly IClienteLoginRepositorio _login;

        private readonly IClienteRepositorio _cliente;

        public ContaController(IContaRepositorio ContaRepositorio, IClienteLoginRepositorio login,IClienteRepositorio cliente)
        {
            _contaRepositorio = ContaRepositorio;
            _login = login;
            _cliente = cliente;
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

        [HttpPut("{cpf}")]
        public IActionResult Update(string cpf, [FromBody] ClienteLogin conta)
        {
            int numeroConta = _contaRepositorio.FindByNumC(cpf);
            var _conta = _contaRepositorio.FindByConta(numeroConta);
            bool contaVerificada = _contaRepositorio.VerifyAccount(_conta);
            var senha = _login.FindByCpf(cpf);

            DateTime alteracaoStatus;

            if (conta.senhaAcesso == senha.senhaAcesso)
            {
                try
                {
                    if (contaVerificada)
                    {
                        _conta.flagAtivo = -1;
                        _contaRepositorio.Update(_conta);

                        alteracaoStatus = DateTime.Now;

                        _contaRepositorio.Status(alteracaoStatus, _conta.flagAtivo, numeroConta);
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
            else
            {
                return BadRequest();
            }
        }

[Route("ativar")]
 [HttpPut]
        public IActionResult Update([FromBody] StatusConta st)
        {


             var cliente = _cliente.FindByCpf(st.cpf);
            if(cliente!=null && cliente.cpf == st.cpf && cliente.rg == st.rg){

            int numeroConta = _contaRepositorio.FindByNumC(st.cpf);
            var _conta = _contaRepositorio.FindByConta(numeroConta);
            bool contaVerificada = _contaRepositorio.VerifyAccount(_conta);
            var clienteLogin = _login.FindByCpf(st.cpf);

            DateTime alteracaoStatus;
            
          
                try
                {
                    if (contaVerificada)
                    {

                        _conta.flagAtivo = 1;
                        _conta.senhaTransacoes = st.senhaTransacoes;
                        _contaRepositorio.Update(_conta);
                        clienteLogin.senhaAcesso = st.senhaAcesso;
                        _login.Update(clienteLogin);

                        alteracaoStatus = DateTime.Now;

                        _contaRepositorio.Status(alteracaoStatus, _conta.flagAtivo, numeroConta);
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

            return BadRequest();
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
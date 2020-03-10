using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;
using System;
using InternetBankingBackEnd.Models;

namespace InternetBanking.Repositorio
{
    public class ContaRepositorio : IContaRepositorio
    {
        private readonly ClienteDB _contexto;
        private readonly ContaDB _contextoConta;
        public ContaRepositorio(ClienteDB ctx, ContaDB ctxConta)
        {
            _contexto = ctx;
            _contextoConta = ctxConta;
        }
        public void AddConta(Conta conta)
        {
            _contexto.Conta.Add(conta);
            _contexto.SaveChanges();
        }
        public Conta FindByConta(int numeroConta)
        {
            return _contexto.Conta.FirstOrDefault(u => u.numeroConta == numeroConta);
        }
        public IEnumerable<Conta> GetAll()
        {
            return _contexto.Conta.ToList();
        }

        public Conta FindByContaOrigem(int numeroConta)
        {
            return _contexto.Conta.FirstOrDefault(c => c.numeroConta == numeroConta);
        }

        public int FindByNumC(string cpf){

           Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);          

            Conta conta = _contexto.Conta.FirstOrDefault(c => c.idCliente == cli.idCliente);
            return conta.numeroConta;
        }

        public Conta FindByContaDestino(int numeroConta)
        {
            return _contexto.Conta.FirstOrDefault(c => c.numeroConta == numeroConta);
        }

        public bool VerifyAccount(Conta conta)
        {
            if(conta.saldoAtual == 0 && conta.flagAtivo == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(Conta conta)
        {
            _contexto.Conta.Update(conta);
            _contexto.SaveChanges();
        }

        public void Deposito(int idConta, int numeroContaDestino, decimal valor)
        {
            var conta = FindByContaDestino(numeroContaDestino);

            if (valor <= 0 ||
             conta == null ||
              numeroContaDestino <= 0 ||
               idConta <= 0)
            {
                Console.WriteLine("Depósito não efetuado.");
            }
            else
            {
                conta.saldoAtual += valor;
                _contexto.SaveChanges();
            }
        }

        public void Saque(int idConta, int numeroContaOrigem, decimal valor)
        {
            var conta = FindByContaOrigem(numeroContaOrigem);

            if (conta.saldoAtual < valor ||
                valor <= 0 ||
             conta == null ||
              numeroContaOrigem <= 0 ||
               idConta <= 0)
            {
                Console.WriteLine("Saque não efetuado.");
            }
            else
            {
                conta.saldoAtual -= valor;
                _contexto.SaveChanges();
            }
        }

        public void Transferencia(int idConta, int numeroContaOrigem,
            int numeroContaDestino, decimal valor)
        {
            var contaOrigem = FindByContaOrigem(numeroContaOrigem);
            var contaDestino = FindByContaDestino(numeroContaDestino);

            if (contaOrigem.saldoAtual < valor ||
             valor <= 0 ||
             idConta <= 0 ||
              numeroContaDestino <= 0 ||
               numeroContaOrigem <= 0 ||
                numeroContaOrigem == numeroContaDestino)
            {
                Console.WriteLine("Transferência não efetuada.");
            }
            else
            {
                contaOrigem.saldoAtual -= valor;
                contaDestino.saldoAtual += valor;
                _contexto.SaveChanges();
            }
        }

        public void Status(DateTime dataAlteracao, int flagAtivo, int numeroConta)
        {
            Status s = new Status();

            s.dataAlteracao = dataAlteracao;
            s.flagAtivo = flagAtivo;
            s.numeroConta = numeroConta;

            _contextoConta.Add(s);
            _contextoConta.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;
using System;

namespace InternetBanking.Repositorio
{
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        private readonly ContaCorrenteDB _contexto;

        public ContaCorrenteRepositorio(ContaCorrenteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddContaCorrente(ContaCorrente contaCorrente)
        {
            _contexto.ContaCorrente.Add(contaCorrente);
            _contexto.SaveChanges();
        }

        public ContaCorrente FindByContaCorrenteOrigem(int numeroConta)
        {
            return _contexto.ContaCorrente.FirstOrDefault(c => c.numeroConta == numeroConta);
        }

        public ContaCorrente FindByContaCorrenteDestino(int numeroConta)
        {
            return _contexto.ContaCorrente.FirstOrDefault(c => c.numeroConta == numeroConta);
        }

        public IEnumerable<ContaCorrente> GetAll()
        {
            return _contexto.ContaCorrente.ToList();
        }

        public void Update(ContaCorrente contaCorrente)
        {
            _contexto.ContaCorrente.Update(contaCorrente);
            _contexto.SaveChanges();
        }

        public void Deposito(int idContaCorrente, int numeroContaCorrenteDestino, decimal valor)
        {
            var contaCorrente = FindByContaCorrenteDestino(numeroContaCorrenteDestino);

            if(valor <= 0)
            {
                Console.WriteLine("Depósito não efetuado.");
            }
            else
            {
                contaCorrente.saldo += valor;
                _contexto.SaveChanges();
            }
        }

        public void Saque(int idContaCorrente, int numeroContaOrigem, decimal valor)
        {
            var contaCorrente = FindByContaCorrenteOrigem(numeroContaOrigem);
            
            if(contaCorrente.saldo < valor || valor <= 0)
            {
                Console.WriteLine("Saque não efetuado.");
            }
            else
            {
                contaCorrente.saldo -= valor;
                _contexto.SaveChanges();
            }
        }

        public void Transferencia(int idContaCorrente, int numeroContaCorrenteOrigem,
            int numeroContaCorrenteDestino, decimal valor)
        {
            var contaCorrenteOrigem = FindByContaCorrenteOrigem(numeroContaCorrenteOrigem);
            var contaCorrenteDestino = FindByContaCorrenteDestino(numeroContaCorrenteDestino);
            
            if(contaCorrenteOrigem.saldo < valor || valor <= 0)
            {
                Console.WriteLine("Transferência não efetuada.");
            }
            else
            {
                contaCorrenteOrigem.saldo -= valor;
                contaCorrenteDestino.saldo += valor;
                _contexto.SaveChanges();
            }
        }
    }
}
using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;

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

        public ContaCorrente FindByContaCorrente(int numConta)
        {
            return _contexto.ContaCorrente.FirstOrDefault(u => u.numConta == numConta);
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

        public void Deposito(int conta, decimal valor)
        {
            var contaCorrente = FindByContaCorrente(conta);
            contaCorrente.saldo += valor;
            _contexto.SaveChanges();
        }

        public void Saque(int conta, decimal valor)
        {
            var contaCorrente = FindByContaCorrente(conta);
            contaCorrente.saldo -= valor;
            _contexto.SaveChanges();
        }
    }
}
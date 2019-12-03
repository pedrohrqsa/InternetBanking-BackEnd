using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public interface IContaCorrenteRepositorio
    {
        void AddContaCorrente(ContaCorrente contaCorrente);
        IEnumerable<ContaCorrente> GetAll();
        ContaCorrente FindByContaCorrente(int id);
        void Update(ContaCorrente contaCorrente);
        void Deposito(int numConta, decimal valor);
        void Saque(int numConta, decimal valor);
    }
}

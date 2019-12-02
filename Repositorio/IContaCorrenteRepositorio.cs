using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public interface IContaCorrenteRepositorio
    {
        void AddContaCorrente(ContaCorrente contaCorrente);
        IEnumerable<ContaCorrente> GetAll();

        void Saque(decimal valor);

        void Deposito(decimal valor);
        ContaCorrente FindByContaCorrente(int idContaCorrente);

        void Update(ContaCorrente contaCorrente);
    }
}

using System.Collections.Generic;
using InternetBanking.Repositorio;

namespace InternetBanking.Repositorio
{
    public interface IContaCorrenteRepositorio
    {
        void AddConta(ContaCorrente contaCorrente);

        IEnumerable<ContaCorrente> GetAll();

        ContaCorrente FindByContaCorrente(int id);
    }
}
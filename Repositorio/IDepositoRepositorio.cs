using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IDepositoRepositorio
    {
        void AddDeposito(Deposito deposito);
        IEnumerable<Deposito> GetAll();
        Deposito FindByDeposito(int deposito);
    }
}
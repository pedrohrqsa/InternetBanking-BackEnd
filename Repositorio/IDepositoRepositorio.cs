using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IDepositoRepositorio
    {
        IEnumerable<Deposito> GetAll();
        Deposito FindByDeposito(int id);
        void Update(Deposito deposito);
    }
}
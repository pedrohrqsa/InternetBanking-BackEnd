using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IDepositoRepositorio
    {
        void AddDeposito(Transacao deposito);
        IEnumerable<Deposito> GetAll();
        Deposito FindByID(int id);
    }
}
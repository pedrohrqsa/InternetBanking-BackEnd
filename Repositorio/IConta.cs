using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IContaRepositorio
    {
        void AddConta(Conta conta);

        IEnumerable<Conta> GetAll();

        Conta FindByConta(int id);
    }
}
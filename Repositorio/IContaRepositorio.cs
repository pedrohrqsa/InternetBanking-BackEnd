using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public interface IContaRepositorio
    {
        void AddConta(Conta conta);
        IEnumerable<Conta> GetAll();
        Conta FindByConta(int conta);
    }
}
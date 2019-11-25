using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IBancoRepositorio
    {
        void AddBanco(Banco banco){}

        Banco FindByBanco(int banco);
       IEnumerable<Banco> GetAll();
    }
}
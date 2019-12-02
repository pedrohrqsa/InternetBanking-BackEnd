using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ISaqueRepositorio
    {
        void AddSaque(Saque saque);
        IEnumerable<Saque> GetAll();
        Saque FindByID(int id);
    }
}
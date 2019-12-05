using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IAgenciaRepositorio
    {
        void AddAgencia(Agencia agencia);
        IEnumerable<Agencia> GetAll();
        Agencia FindByAgencia(int numeroAgencia);
    }
}
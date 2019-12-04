using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ITransferenciaRepositorio
    {
        void AddTransferencia(Transferencia transferencia);
        IEnumerable<Transferencia> GetAll();
        Transferencia FindByID(int id);
    }
}
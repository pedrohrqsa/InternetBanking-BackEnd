using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ISaqueRepositorio
    {
        void AddSaque(Saque Saque);
        IEnumerable<Saque> GetAll();
        Saque FindByCpf(string cpf);
    }
}
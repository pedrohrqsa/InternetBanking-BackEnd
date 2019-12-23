using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IFamiliaresRepositorio
    {
        void AddFamiliares(Familiares familiares);
        IEnumerable<Familiares> GetAll();
        Familiares FindByFam(int Fam);
        int FindByIdCliente(string cpf);
        void Update(Familiares familiares);
    }
}
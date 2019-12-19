using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IContatoRepositorio
    {
        void AddContato(Contato contato);
        IEnumerable<Contato> GetAll();
        Contato FindByContato(int contato);
        void Update(Contato contato);

    }
}
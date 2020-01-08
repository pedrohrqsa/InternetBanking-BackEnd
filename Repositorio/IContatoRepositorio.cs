using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IContatoRepositorio
    {
        void AddContato(Contato contato);
        IEnumerable<Contato> GetAll();
        int FindByIdCliente(string cpf);
        Contato FindByContato(int contato);
        void Update(Contato contato);
        void Update(Contato contato,Contato _contato);

    }
}
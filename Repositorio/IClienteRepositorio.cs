using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IClienteRepositorio
    {
        void Add(ClienteCad cliente);
        IEnumerable<ClienteLogin> GetAll();
        ClienteLogin Find(int id);
       ClienteLogin FindByCpf(string cpf);
    }
}
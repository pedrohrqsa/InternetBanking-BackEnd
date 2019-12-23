using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IClienteLoginRepositorio
    {
        void AddClienteLogin(ClienteLogin clienteLogin);
        IEnumerable<ClienteLogin> GetAll();
        ClienteLogin FindByCpf(string cpf);
        int FindByIdCliente(string cpf);
        void Update(ClienteLogin clienteLogin);

    }
}
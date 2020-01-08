using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IClienteRepositorio
    {
        void AddCliente(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        Cliente FindByCpf(string cpf);
        int FindByIdCliente(string cpf);
        void Update(Cliente cliente);
        void Update(Cliente cliente, Cliente _cliente);
    }
}
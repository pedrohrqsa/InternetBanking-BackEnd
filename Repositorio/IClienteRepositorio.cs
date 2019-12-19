using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IClienteRepositorio
    {
        void AddCliente(Cliente cliente);
        IEnumerable<Cliente> GetAll();
        Cliente FindByCpf(string cpf);
        void Update(Cliente cliente);
    }
}
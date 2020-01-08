using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IEnderecoRepositorio
    {
        void AddEndereco(Endereco endereco);
        IEnumerable<Endereco> GetAll();
        Endereco FindByEnd(int endereco);
        int FindByIdCliente(string cpf);
        void Update(Endereco endereco);
        void Update(Endereco endereco, Endereco _endereco);
    }
}
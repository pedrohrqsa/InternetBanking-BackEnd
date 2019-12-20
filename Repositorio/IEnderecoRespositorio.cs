using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IEnderecoRepositorio
    {
        void AddEndereco(Endereco endereco);
        IEnumerable<Endereco> GetAll();
        Endereco FindByEnd(string cep);
        void Update(Endereco endereco);
    }
}
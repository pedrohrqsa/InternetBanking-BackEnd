using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IEnderecoController
    {
        void AddEndereco(Endereco endereco);
        IEnumerable<Endereco> GetAll();
        Endereco FindByEndCli(string Cli);
    }
}
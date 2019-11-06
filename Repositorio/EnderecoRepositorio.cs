using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class EnderecoRepositorio : IEnderecoController
    {
        private readonly ClienteDB _contexto;
        public EnderecoRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddEndereco(Endereco endereco)
        {
            _contexto.Add(endereco);
            _contexto.SaveChanges();
        }
        public Endereco FindByEndCli(string cep)
        {
            return _contexto.Enderecos.FirstOrDefault(c => c.CEP == cep);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Enderecos.ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
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
        public Endereco FindByEnd(string cep)
        {
            return _contexto.Endereco.FirstOrDefault(c => c.CEP == cep);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Endereco.ToList();
        }
    }
}
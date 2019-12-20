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
        public Endereco FindByEnd(int endereco)
        {
            return _contexto.Endereco.FirstOrDefault(c => c.idCliente == endereco);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Endereco.ToList();
        }
        public void Update(Endereco endereco)
        {
            _contexto.Endereco.Update(endereco);
            _contexto.SaveChanges();
        }
    }
}
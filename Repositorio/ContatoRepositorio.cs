using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ClienteDB _contexto;
        public ContatoRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddContato(Contato contato)
        {
            _contexto.Contato.Add(contato);
            _contexto.SaveChanges();
        }
        public Contato FindByContato(int contato)
        {
            return _contexto.Contato.FirstOrDefault(u => u.ID_CLIENTE == contato);
        }
        public IEnumerable<Contato> GetAll()
        {
            return _contexto.Contato.ToList();
        }
    }
}
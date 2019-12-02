using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class SaqueRepositorio : ISaqueRepositorio
    {
        private readonly TransacaoDB _contexto;
        public SaqueRepositorio(TransacaoDB ctx)
        {
            _contexto = ctx;
        }

        public void AddSaque(Saque saque){
            _contexto.Saque.Add(saque);
            _contexto.SaveChanges();
        }

        public Saque FindByID(int id)
        {
            return _contexto.Saque.FirstOrDefault(u => u.idSaque == id);
        }

        public IEnumerable<Saque> GetAll()
        {
            return _contexto.Saque.ToList();
        }
    }
}
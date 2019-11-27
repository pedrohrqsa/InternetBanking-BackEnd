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
        public void AddSaque(Saque saque)
        {
            _contexto.Saque.Add(saque);
            _contexto.SaveChanges();
        }
        public Saque FindBySaque(int saque)
        {
            return _contexto.Saque.FirstOrDefault(u => u.idSaque == saque);
        }
        public IEnumerable<Saque> GetAll()
        {
            return _contexto.Saque.ToList();
        }
    }
}
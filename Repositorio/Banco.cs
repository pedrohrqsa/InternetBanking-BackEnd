using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class BancoRepositorio
    {
        private readonly ContaDb _contexto;
        
        public BancoRepositorio(ContaDb ctx){
            _contexto = ctx;
        }

        public void AddBanco(Banco banco)
        {
            _contexto.Banco.Add(banco);
            _contexto.SaveChanges();
        }

        public Banco FindByBanco(int banco)
        {
            return _contexto.Banco.FirstOrDefault(u => u.idBanco == banco);
        }
        public IEnumerable<Banco> GetAll()
        {
            return _contexto.Banco.ToList();
        }
    }
}
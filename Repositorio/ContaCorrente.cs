using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
using InternetBanking.Repositorio;

namespace InternetBanking.Repositorio
{
    public class ContaCorrente
    {
        private readonly ContaDb _contexto;
        
        public ContaCorrente(ContaDb ctx){
            _contexto = ctx;
        }

        public void AddContaCorrente(ContaCorrente contaCorrente)
        {
            _contexto.ContaCorrente.Add(contaCorrente);
            _contexto.SaveChanges();
        }

        public ContaCorrente FindByContaCorrente(int contaCorrente)
        {
            return _contexto.ContaCorrente.FirstOrDefault(u => u.idContaCorrente == contaCorrente);
        }
        public IEnumerable<ContaCorrente> GetAll()
        {
            return _contexto.ContaCorrente.ToList();
        }
    }
}
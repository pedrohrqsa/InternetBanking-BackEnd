using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;

namespace InternetBanking.Repositorio
{
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        private readonly ClienteDB _contexto;
        public ContaCorrenteRepositorio(ClienteDB ctx)
        {
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
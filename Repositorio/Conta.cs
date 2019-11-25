using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class ContaRepositorio: IContaRepositorio
    {
        private readonly ContaDb _contexto;
        
        public ContaRepositorio(ContaDb ctx){
            _contexto = ctx;
        }

        public void AddConta(Conta conta)
        {
            _contexto.Conta.Add(conta);
            _contexto.SaveChanges();
        }

        public Conta FindByConta(int conta)
        {
            return _contexto.Conta.FirstOrDefault(u => u.idCliente == conta);
        }
        public IEnumerable<Conta> GetAll()
        {
            return _contexto.Conta.ToList();
        }

    }
}
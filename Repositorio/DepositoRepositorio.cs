using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class DepositoRepositorio : IDepositoRepositorio
    {
        private readonly TransacaoDB _contexto;
        public DepositoRepositorio(TransacaoDB ctx)
        {
            _contexto = ctx;
        }

        public void AddDeposito(Deposito deposito){
            _contexto.Deposito.Add(deposito);
            _contexto.SaveChanges();
        }

        public Deposito FindByID(int id)
        {
            return _contexto.Deposito.FirstOrDefault(u => u.idDeposito == id);
        }

        public IEnumerable<Deposito> GetAll()
        {
            return _contexto.Deposito.ToList();
        }
    }
}
using System.Collections.Generic;
using InternetBanking.Models;
using System.Linq;

namespace InternetBanking.Repositorio
{
    public class AgenciaRepositorio : IAgenciaRepositorio
    {
        private readonly ContaDB _contexto;
        public AgenciaRepositorio(ContaDB ctx)
        {
            _contexto = ctx;
        }
        public void AddAgencia(Agencia agencia)
        {
            _contexto.Agencia.Add(agencia);
            _contexto.SaveChanges();
        }
        public Agencia FindByAgencia(int agencia)
        {
            return _contexto.Agencia.FirstOrDefault(u => u.idAgencia == agencia);
        }
        public IEnumerable<Agencia> GetAll()
        {
            return _contexto.Agencia.ToList();
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
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

        public Agencia FindByAgencia(int numeroAgencia)
        {
            return _contexto.Agencia.FirstOrDefault(c => c.numeroAgencia == numeroAgencia);
        }

        public IEnumerable<Agencia> GetAll()
        {
            return _contexto.Agencia.ToList();
        }
    }
}
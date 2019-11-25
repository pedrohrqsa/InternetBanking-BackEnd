using System.Collections.Generic;
using System.Linq;

namespace InternetBanking.Repositorio
{
    public class AgenciaRepositorio
    {
        private readonly ContaDb _contexto;
        
        public AgenciaRepositorio(ContaDb ctx){
            _contexto = ctx;
        }

        public void AddAgencia(Agencia agencia)
        {
            _contexto.Agencia.Add(agencia);
            _contexto.SaveChanges();
        }

        public Agencia FindByBanco(int agencia)
        {
            return _contexto.Agencia.FirstOrDefault(u => u.idAgencia == agencia);
        }
        public IEnumerable<Agencia> GetAll()
        {
            return _contexto.Agencia.ToList();
        }
    }
}
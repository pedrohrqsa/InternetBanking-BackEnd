using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class TransferenciaRepositorio : ITransferenciaRepositorio
    {
        private readonly TransacaoDB _contexto;
        
        public TransferenciaRepositorio(TransacaoDB ctx)
        {
            _contexto = ctx;
        }

        public void AddTransferencia(Transferencia transferencia){
            _contexto.Transferencia.Add(transferencia);
            _contexto.SaveChanges();
        }

        public Transferencia FindByID(int id)
        {
            return _contexto.Transferencia.FirstOrDefault(u => u.idTransferencia == id);
        }

        public IEnumerable<Transferencia> GetAll()
        {
            return _contexto.Transferencia.ToList();
        }
    }
}
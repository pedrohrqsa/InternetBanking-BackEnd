using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class SaqueRepositorio : ISaqueRepositorio
    {
        private readonly ClienteDB _contexto;

        public ClienteRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        
        public void AddSaque(Saque saque)
        {
            _contexto.Saque.Add(saque);
            _contexto.SaveChanges();
        }
        public Cliente FindByCpf(string cpf)
        {
            return _contexto.Saque.FirstOrDefault(c => c.cpf == cpf);
        }

        public IEnumerable<Saque> GetAll()
        {
            return _contexto.Saque.ToList();
        }
    }
}
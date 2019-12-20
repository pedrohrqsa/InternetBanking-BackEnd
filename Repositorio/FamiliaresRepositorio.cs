using System.Linq;
using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public class FamiliaresRepositorio : IFamiliaresRepositorio
    {
        private readonly ClienteDB _contexto;
        public FamiliaresRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddFamiliares(Familiares familiares)
        {
            _contexto.Familiares.Add(familiares);
            _contexto.SaveChanges();
        }
        public Familiares FindByFam(int Fam)
        {
            return _contexto.Familiares.FirstOrDefault(
                e => e.idCliente == Fam
            );
        }
        public IEnumerable<Familiares> GetAll()
        {
            return _contexto.Familiares.ToList();
        }

        public void Update(Familiares familiares)
        {
            _contexto.Familiares.Update(familiares);
            _contexto.SaveChanges();
        }
    }
}
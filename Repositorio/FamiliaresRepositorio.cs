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

        public int FindByIdCliente(string cpf)
        {
            Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);
            return cli.idCliente;
        }

        public void Update(Familiares familiares)
        {
            _contexto.Familiares.Update(familiares);
            _contexto.SaveChanges();
        }

        public void Update(Familiares familiares, Familiares _familiares) 
        {

            if(familiares.nomeMae!=""){_familiares.nomeMae = familiares.nomeMae;}
            if(familiares.sobrenomeMae!=""){_familiares.sobrenomeMae = familiares.sobrenomeMae;}           
            if(familiares.sobrenomePai!=""){ _familiares.sobrenomePai = familiares.sobrenomePai;}
            if(familiares.nomePai!=""){ _familiares.nomePai = familiares.nomePai;}
    
            _contexto.Familiares.Update(_familiares);
            _contexto.SaveChanges();
        }


                   
}

}
using System.Linq;
using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public class FotoRepositorio : IFotoRepositorio
    {
        private readonly ClienteDB _contexto;
        public FotoRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddFoto(Foto foto)
        {
            _contexto.Foto.Add(foto);
            _contexto.SaveChanges();
        }
        public Foto FindByFoto(int IdFoto)
        {
            return _contexto.Foto.FirstOrDefault(
                e => e.idCliente == IdFoto
            );
        }
        public IEnumerable<Foto> GetAll()
        {
            return _contexto.Foto.ToList();
        }
    }
}
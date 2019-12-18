using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface IFotoRepositorio
    {
        void AddFoto(Foto foto);
        IEnumerable<Foto> GetAll();
        Foto FindByFoto(int IdFoto);
    }
}
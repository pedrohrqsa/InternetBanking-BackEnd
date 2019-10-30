using System.Collections.Generic;
using test.Models;

namespace test.Repositorio
{
    public interface IUsuarioRepositorio
    {
         void Add(Usuario user);
         IEnumerable<Usuario> GetAll();
         Usuario Find (long id);
         void Remove(long id);
         void Update(Usuario user);
    }
}
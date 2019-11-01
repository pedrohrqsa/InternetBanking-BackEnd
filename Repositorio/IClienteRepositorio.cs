using System.Collections.Generic;
using test.Models;

namespace test.Repositorio
{
    public interface IClienteRepositorio
    {
         void Add (Cliente cliente);

        IEnumerable<Cliente> GetAll();

         Cliente Find (long id);
    }
}
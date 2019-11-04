using System.Collections.Generic;
using test.Models;

namespace test.Repositorio
{
    public interface IClienteRepositorio
    {
        IEnumerable<Cliente> GetAll();
         Cliente Find (int id);
    }
}
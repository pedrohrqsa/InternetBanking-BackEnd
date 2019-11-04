using System.Collections.Generic;
using System.Linq;
using test.Models;

namespace test.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteDbContext _contexto;

        public ClienteRepositorio(ClienteDbContext ctx)
        {
            _contexto = ctx;
        }
        
        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.Clientes.ToList();
        }
        public Cliente Find(int id)
        {
            return _contexto.Clientes.FirstOrDefault(
                u => u.Id_login == id
                );
        }
    }
}
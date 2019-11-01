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

        public void Add(Cliente cliente)
        {
            _contexto.Cliente.Add(cliente);
            _contexto.SaveChanges();
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.Cliente.ToList();
        }
        public Cliente Find(long id)
        {
            return _contexto.Cliente.FirstOrDefault(
                u => u.ID_CLIENTE == id
                );
        }
    }
}
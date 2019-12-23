using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteDB _contexto;

        public ClienteRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddCliente(Cliente cliente)
        {
            _contexto.Cliente.Add(cliente);
            _contexto.SaveChanges();
        }

        public Cliente FindByCpf(string cpf)
        {
            return _contexto.Cliente.FirstOrDefault(c => c.cpf == cpf);
        }
        
        public int FindByIdCliente(string cpf)
        {
            Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);
            return cli.idCliente;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.Cliente.ToList();
        }

        public void Update(Cliente cliente)
        {
            _contexto.Cliente.Update(cliente);
            _contexto.SaveChanges();
        }
    }
}
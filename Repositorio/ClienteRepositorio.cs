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

        public void Update(Cliente cliente, Cliente _cliente)
        {

            if (cliente.nome != "") { _cliente.nome = cliente.nome; }
            if (cliente.sobrenome != "") { _cliente.sobrenome = cliente.sobrenome; }
            if (cliente.rg != "") { _cliente.rg = cliente.rg; }
            if (cliente.orgaoEmissor != "") { _cliente.orgaoEmissor = cliente.orgaoEmissor; }
            if (cliente.dtNascimento != null) { _cliente.dtNascimento = cliente.dtNascimento; }            
            if (cliente.naturalidade != "") { _cliente.naturalidade = cliente.naturalidade; }
            if (cliente.nacionalidade != "") { _cliente.nacionalidade = cliente.nacionalidade; }
            
            _contexto.Cliente.Update(_cliente);
            _contexto.SaveChanges();
        }

        


        
    }
}
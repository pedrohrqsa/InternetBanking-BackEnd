using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class ClienteLoginRepositorio : IClienteLoginRepositorio
    {
        private readonly ClienteDB _contexto;
        public ClienteLoginRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }
        public void AddClienteLogin(ClienteLogin clienteLogin)
        {
            _contexto.ClienteLogin.Add(clienteLogin);
            _contexto.SaveChanges();
        }
        
        public ClienteLogin FindByCpf(string cpf)
        {
         return  _contexto.ClienteLogin.FirstOrDefault(c => c.CPF == cpf);
        }
        public IEnumerable<ClienteLogin> GetAll()
        {
            return _contexto.ClienteLogin.ToList();
        }
    }
}
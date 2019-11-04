using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ClienteDbContext _contexto;

        public ClienteRepositorio(ClienteDbContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(ClienteCad clientes)
        {
            _contexto.ClientesCad.Add(clientes);
            _contexto.SaveChanges();
        }
        public IEnumerable<ClienteLogin> GetAll()
        {
            return _contexto.ClienteLogin.ToList();
        }
        public ClienteLogin FindByCpf(string cpf){
            return _contexto.ClienteLogin.FirstOrDefault(c => c.CPF == cpf);
        }
        public ClienteLogin Find(int id)
        {
            return _contexto.ClienteLogin.FirstOrDefault(
                u => u.Id_login == id
                );
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Controllers;
using InternetBanking.Models;
using System;

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
            return _contexto.Cliente.FirstOrDefault(c => c.CPF == cpf);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _contexto.Cliente.ToList();
        }

        // public Cliente FindByIdCliente(int id)
        // {
        //     return _contexto.Cliente.FirstOrDefault(Id=> Id.ID_CLIENTE == id);
        // }
    }
}
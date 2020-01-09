using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private readonly ClienteDB _contexto;
        
        public EnderecoRepositorio(ClienteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddEndereco(Endereco endereco)
        {
            _contexto.Add(endereco);
            _contexto.SaveChanges();
        }

        public Endereco FindByEnd(int endereco)
        {
            return _contexto.Endereco.FirstOrDefault(c => c.idCliente == endereco);
        }

        public IEnumerable<Endereco> GetAll()
        {
            return _contexto.Endereco.ToList();
        }
        
        public int FindByIdCliente(string cpf)
        {
            Cliente cli = _contexto.Cliente.FirstOrDefault(cli => cli.cpf == cpf);
            return cli.idCliente;
        }

        public void Update(Endereco endereco)
        {
            _contexto.Endereco.Update(endereco);
            _contexto.SaveChanges();
        }

        public void Update(Endereco endereco, Endereco _endereco)
        {   
           if(endereco.numero != ""){ _endereco.numero = endereco.numero;}
           if(endereco.logradouro != ""){_endereco.logradouro = endereco.logradouro;}
           if(endereco.complemento != ""){ _endereco.complemento = endereco.complemento;}
           if(endereco.bairro != ""){ _endereco.bairro = endereco.bairro;}
           if(endereco.cidade != ""){ _endereco.cidade = endereco.cidade;}
           if(endereco.siglaEstado != ""){ _endereco.siglaEstado = endereco.siglaEstado;}
           if(endereco.cep != ""){ _endereco.cep = endereco.cep;}

            _contexto.Endereco.Update(_endereco);
            _contexto.SaveChanges();
        }
    }
}

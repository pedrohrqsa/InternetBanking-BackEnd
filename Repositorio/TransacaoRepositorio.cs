using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly ContaCorrenteDB _contexto;
        public TransacaoRepositorio(ContaCorrenteDB ctx)
        {
            _contexto = ctx;
        }

        public void AddTransacao(Transacao transacao){
            _contexto.Transacao.Add(transacao);
            _contexto.SaveChanges();
        }

        public Transacao FindByID(int id)
        {
            return _contexto.Transacao.FirstOrDefault(u => u.idTransacao == id);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _contexto.Transacao.ToList();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly TransacaoDB _contexto;
        
        public TransacaoRepositorio(TransacaoDB ctx)
        {
            _contexto = ctx;
        }

        public Transacao FindByID(int id)
        {
            return _contexto.Transacao.FirstOrDefault(u => u.idTransacao == id);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _contexto.Transacao.ToList();
        }
        
        public void AddTransacao(Transacao transacao)
        {
            _contexto.Transacao.Add(transacao);
            _contexto.SaveChanges();
        }
        
        public void Deposito(Transacao deposito)
        {
            _contexto.Transacao.Add(deposito);
            _contexto.SaveChanges();
        }
        
        public void Saque(Transacao saque)
        {
            _contexto.Transacao.Add(saque);
            _contexto.SaveChanges();
        }
    }
}
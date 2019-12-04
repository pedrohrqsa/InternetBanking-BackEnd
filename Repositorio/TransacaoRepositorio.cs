using System;
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly TransacaoDB _contextoTransacao;
        private readonly ContaCorrenteDB _contextoContaCorrente;

        public TransacaoRepositorio(TransacaoDB ctxTransacao, ContaCorrenteDB ctxContaCorrente)
        {
            _contextoTransacao = ctxTransacao;
            _contextoContaCorrente = ctxContaCorrente;
        }

        public Transacao FindByID(int id)
        {
            return _contextoTransacao.Transacao.FirstOrDefault(u => u.idTransacao == id);
        }

        public IEnumerable<Transacao> GetAll()
        {
            return _contextoTransacao.Transacao.ToList();
        }

        // public void Deposito(Transacao deposito)
        // {
        //     _contextoTransacao.Transacao.Add(deposito);
        //     _contextoTransacao.SaveChanges();
        // }

        public void AddTransacao(Transacao transacao)
        {
            _contextoTransacao.Transacao.Add(transacao);
        }

        public bool Deposito(Deposito deposito)
        {
            try
            {
                _contextoTransacao.Add(deposito);
                _contextoTransacao.SaveChanges();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
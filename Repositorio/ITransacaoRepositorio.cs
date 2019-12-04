using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ITransacaoRepositorio
    {
        void AddTransacao(Transacao transacao);
        IEnumerable<Transacao> GetAll();
        Transacao FindByID(int id);
        void Update(Deposito deposito);
        bool Deposito(Transacao deposito);
        // void Saque(Transacao saque);
    }
}
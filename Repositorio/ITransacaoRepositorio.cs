using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ITransacaoRepositorio
    {
        void AddTransacao(Transacao transacao);
        IEnumerable<Transacao> GetAll(int numeroConta);
        Transacao FindByID(int id);
        bool Deposito(Transacao deposito);
        bool Saque(Transacao saque);
        bool Transferencia(Transacao transferencia);
    }
}
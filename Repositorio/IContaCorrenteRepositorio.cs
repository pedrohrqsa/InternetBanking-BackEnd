using InternetBanking.Models;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public interface IContaCorrenteRepositorio
    {
        void AddContaCorrente(ContaCorrente contaCorrente);
        IEnumerable<ContaCorrente> GetAll();
        ContaCorrente FindByContaCorrenteOrigem(int numeroContaOrigem);
        ContaCorrente FindByContaCorrenteDestino(int numeroContaDestino);
        void Update(ContaCorrente contaCorrente);
        void Deposito(int idContaCorrente, int numeroConta, decimal valor);
        void Saque(int idContaCorrente, int numeroConta, decimal valor);
        void Transferencia(int idContaCorrente, int numeroContaOrigem, int numeroContaDestino, decimal valor);
    }
}

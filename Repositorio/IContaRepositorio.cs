using InternetBanking.Models;
using InternetBankingBackEnd.Models;
using System;
using System.Collections.Generic;

namespace InternetBanking.Repositorio
{
    public interface IContaRepositorio
    {
        void AddConta(Conta conta);
        IEnumerable<Conta> GetAll();
        Conta FindByContaOrigem(int numeroContaOrigem);
        Conta FindByContaDestino(int numeroContaDestino);
        Conta FindByConta(int numeroConta);
        bool VerifyAccount(Conta conta);
        void Status(DateTime dataAlteracao, int flag, int numeroConta);
        int FindByNumC(string cpf);
        void Update(Conta conta);
        void Deposito(int idContaCorrente, int numeroConta, decimal valor);
        void Saque(int idContaCorrente, int numeroConta, decimal valor);
        void Transferencia(int idContaCorrente, int numeroContaOrigem, int numeroContaDestino, decimal valor);
    }
}
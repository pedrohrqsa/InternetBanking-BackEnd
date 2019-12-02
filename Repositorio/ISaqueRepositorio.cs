using System.Collections.Generic;
using InternetBanking.Models;

namespace InternetBanking.Repositorio
{
    public interface ISaqueRepositorio
    {
         void AddSaque(Saque saque);
        IEnumerable<Saque> GetAll();
        decimal GetById(int saque);
        decimal validaSaque(decimal valorSaque, decimal saldoAtual);
    }
}
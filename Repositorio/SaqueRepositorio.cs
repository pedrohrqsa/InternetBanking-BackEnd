using System;
using System.Collections.Generic;
using System.Linq;
using InternetBanking.Models;
namespace InternetBanking.Repositorio
{
    public class SaqueRepositorio : ISaqueRepositorio
    {
        private readonly TransacaoDB _contexto;
        public SaqueRepositorio(TransacaoDB ctx)
        {
            _contexto = ctx;
        }
        public void AddSaque(Saque saque)
        {
            _contexto.Saque.Add(saque);
            _contexto.SaveChanges();
        }
        public Saque GetById(int saque)
        {
            return _contexto.Saque.FirstOrDefault(u => u.idSaque == saque);
        }
        public IEnumerable<Saque> GetAll()
        {
            return _contexto.Saque.ToList();
        }
        public decimal validaSaque(decimal valorSaque, decimal saldoAtual){

            ContaCorrente conta = new ContaCorrente();

            saldoAtual = conta.saldo;
            
            Console.WriteLine(saldoAtual);

            if(saldoAtual > 0 && valorSaque <= saldoAtual){
                return saldoAtual - valorSaque;
            } else {
                throw new System.ArgumentException("Você não possui saldo para realizar essa operação"); 
            }
        }
    }
}
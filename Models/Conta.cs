using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Conta")]
    public class Conta
    {
        public Conta()
        {
            flagAtivo = 1;
        }
        
        [Key]
        public int numeroConta { get; set; }
        public int idCliente { get; set; }
        // public int idAgencia { get; set; }
        public string senhaTransacoes { get; set; }
        public decimal saldoAtual { get; set; }
        public int flagAtivo{ get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }

        // [ForeignKey("idAgencia")]
        // public Agencia Agencia { get; set; }

        public ICollection <Transacao> Transacao { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        public int idConta { get; set; }
        public int idCliente { get; set; }
        // public int Agencia { get; set; }
        public string senhaTransacoes { get; set; }
        public int numeroConta {get; set;}
        public decimal saldoAtual { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }

        public ICollection <Transacao> Transacao { get; set; }
    }
}
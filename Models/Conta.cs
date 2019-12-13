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
        public int numeroConta { get; set; }
        public int idCliente { get; set; }
        // public int idAgencia { get; set; }
        public string senhaTransacoes { get; set; }
        public decimal saldoAtual { get; set; }
        public int flagAtivo{ get; set; }
        // public char flagAtivo
        // {
        //     get
        //     {
        //         return '1';
        //     }
        //     set
        //     {
        //         this.flagAtivo = value;
        //     }
        // }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }

        // [ForeignKey("idAgencia")]
        // public Agencia Agencia { get; set; }

        public ICollection <Transacao> Transacao { get; set; }
    }
}
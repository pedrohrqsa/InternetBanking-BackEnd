using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class Transacao
    {
        [Key]
        public int idTransacao { get; set; }
        public int idContaCorrente { get; set; }
        public DateTime dtTransacao { get; set; }
        public decimal valor { get; set; }

        [ForeignKey("idContaCorrente")]
        public ContaCorrente ContaCorrente { get; set; }
        public ICollection <Saque> Saque { get; set; }
        public ICollection <Deposito> Deposito { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class Conta
    {
        [Key]
        public int idConta { get; set; }
        public int idCliente { get; set; }
        public int Agencia { get; set; }
        public int Banco { get; set; }
        public string senhaTransacoes { get; set; }
        public DateTime dtCriacao { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
        public ICollection <ContaCorrente> ContaCorrente { get; set; }
        
    }
}
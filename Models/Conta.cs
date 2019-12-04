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
        public string senhaTransacoes { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
        public ICollection <Agencia> Agencia { get; set; }
        public ICollection <ContaCorrente> ContaCorrente { get; set; }
    }
}
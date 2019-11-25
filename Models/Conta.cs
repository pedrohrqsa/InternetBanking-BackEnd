using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InternetBanking.Models;

namespace InternetBanking.Models
{
    [Table("Conta")]
    public class Conta
    {
        [Key]
        public int idConta { get; set; }
        public int idCliente { get; set; }
        public string idAgencia { get; set; }
        public string idBanco { get; set; }
        public string senhaTransacoes { get; set; }
        public string dtCriacao { get; set; }
        
        [ForeignKey("idCliente")]
        public Cliente Cliente {get; set;}

        [ForeignKey("idAgencia")]
        public Agencia Agencia {get; set;}

        [ForeignKey("idBanco")]
        public Banco Banco {get; set;}
    }
}
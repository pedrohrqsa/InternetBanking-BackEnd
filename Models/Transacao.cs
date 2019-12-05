using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Transacao")]
    public class Transacao
    {
        [Key]
        public int idTransacao { get; set; }
        public int idConta { get; set; }
        public int idTipoTransacao { get; set; }
        public int numeroContaOrigem { get; set; }
        public int numeroContaDestino { get; set; }
        public decimal valor { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta { get; set; }
    }
}
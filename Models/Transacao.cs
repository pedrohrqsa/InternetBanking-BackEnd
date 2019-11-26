using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class Transacao
    {
        [Key]
        public int idTransacao { get; set; }
        public int idConta { get; set; }
        public DateTime dtTransacao { get; set; }
        public float valor { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta { get; set; }
    }
}
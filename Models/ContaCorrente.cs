using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("ContaCorrente")]
    public class ContaCorrente
    {
        [Key]
        public int idContaCorrente { get; set; }
        public int idConta { get; set; }
        public int numeroConta { get; set; }
        public decimal saldo { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta { get; set; }
        public ICollection <Transacao> Transacao { get; set; }
    }
}
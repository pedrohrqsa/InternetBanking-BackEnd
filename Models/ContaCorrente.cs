using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class ContaCorrente
    {
        [Key]
        public int idContaCorrente { get; set; }
        public int idConta { get; set; }
        public int numConta { get; set; }
        public decimal saldo { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta { get; set; }
        public ICollection <Transacao> Transacao { get; set; }
    }
}
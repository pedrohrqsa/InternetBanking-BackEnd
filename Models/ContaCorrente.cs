using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InternetBanking.Models;

namespace InternetBanking.Models
{
   [Table("ContaCorrente")]
    public class ContaCorrente
    {
        [Key]
        public int idContaCorrente { get; set; }
        public int idConta { get; set; }
        public int numConta { get; set; }
        public int saldo { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta {get; set;}
    }
}
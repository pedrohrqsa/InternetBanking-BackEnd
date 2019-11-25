using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Deposito")]
    public class Deposito
    {
        [Key]
        public int idDeposito { get; set; }
        public int contaDestino { get; set; }
    }
}
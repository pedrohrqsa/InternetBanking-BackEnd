using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InternetBanking.Models;

namespace InternetBanking.Models
{
    [Table("Agencia")]
    public class Agencia
    {
        [Key]
        public int idAgencia { get; set; }
        public int idBanco { get; set; }
        public string numAgencia { get; set; }
        
        [ForeignKey("idBanco")]
        public Banco Banco {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Agencia")]
    public class Agencia
    {
        [Key]
        public int idAgencia { get; set; }
        public int idConta { get; set; }
        public string cepAgencia { get; set; }
        public int numeroAgencia { get; set; }

        [ForeignKey("idConta")]
        public Conta Conta{ get; set; }
    }
}
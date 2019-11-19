using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{

    [Table("Familiares")]
    public class Familiares
    {
        [Key]
        public int idFamiliares { get; set; }
        public int idCliente { get; set; }
        public string nomeMae { get; set; }
        public string sobrenomeMae { get; set; }
        public string nomePai { get; set; }
        public string sobrenomePai { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternetBanking.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Key]
        public int idContato { get; set; }
        public int idCliente { get; set; }
        public string email { get; set; }
        public string telResid { get; set; }
        public string telCel { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
    }
}

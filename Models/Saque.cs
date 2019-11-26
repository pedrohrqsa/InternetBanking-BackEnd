using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    public class Saque
    {
        [Key]
        public int idSaque { get; set; }
        public int idTransacao { get; set; }
        public decimal valor { get; set; }

        [ForeignKey("idTransacao")]
        public Transacao Transacao { get; set; }
    }
}
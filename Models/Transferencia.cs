using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Transferencia")]
    public class Transferencia
    {
        [Key]
        public int idTransferencia { get; set; }
        public int idTransacao { get; set; }
        public decimal valor { get; set; }

        [ForeignKey("idTransacao")]
        public Transacao Transacao { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternetBanking.Models
{
    [Table("CONTATO")]
    public class Contato
    {
        // [Key]
        // public int ID_CONTATO { get; set; }
        [Key]
        public int ID_CLIENTE { get; set; }
        public string Email { get; set; }
        public string TEL_RESID { get; set; }
        public string TEL_CEL { get; set; }
    }
}

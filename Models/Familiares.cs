using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{

    [Table("FAMILIARES")]
    public class Familiares
    {
        [Key]
        public int ID_FAMILIARES { get; set; }
        public int ID_CLIENTE { get; set; }
        public string NOME_MAE { get; set; }
        public string SOBRENOME_MAE { get; set; }
        public string NOME_PAI { get; set; }
        public string SOBRENOME_PAI { get; set; }

        [ForeignKey("ID_CLIENTE")]
        public Cliente Cliente { get; set; }
    }
}
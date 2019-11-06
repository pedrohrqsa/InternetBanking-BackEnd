using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{

    [Table("INFOS_FAMILIARES")]
    public class Familiares
    {
        [Key]
        public int id_fam{ get; set; }
        public int FK_CLIENTES{get; set;}
        public string NOME_MAE { get; set; }
        public string SOBRENOME_MAE { get; set; }
        public string NOME_PAI { get; set; }
        public string SOBRENOME_PAI { get; set; }
    }
}
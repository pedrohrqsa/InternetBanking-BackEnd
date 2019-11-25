using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Banco")]
    public class Banco
    {
        [Key]
        public int idBanco { get; set; }
        public int idEndereco { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }
        public string ispb { get; set; }
        
        // [ForeignKey("idEndereco")]
        // public Endereco Endereco {get; set;}
    }
}
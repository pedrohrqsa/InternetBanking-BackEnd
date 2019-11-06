using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using InternetBanking.Models;

namespace InternetBanking.Models
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        public int ID_CLIENTE{get;set;}
        public string CPF { get; set; }
        public string RG { get; set; }
        public string ORGAOEMISSOR { get; set; }
        public string DTNASCIMENTO { get; set; }
        public string NOME { get; set; }
        public string SOBRENOME { get; set; }
        public string NACIONALIDADE { get; set; }
        public string NATURALIDADE { get; set; }
        public Endereco ENDERECO { get; set; }
        public Familiares INFOFAMILIARES { get; set; }
        public Contato CONTATO { get; set; }
    }
}
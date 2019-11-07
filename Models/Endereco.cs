using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("ENDERECO")]
    public class Endereco
    {
        [Key]
        public int ID_ENDERECO { get; set; }
        public int ID_CLIENTE {get; set;}
        public string LOGRADOURO { get; set; }
        public int NUMERO { get; set; }
        public string COMPLEMENTO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string SIGLA_ESTADO { get; set; }
        public string CEP { get; set; }
        public string FLAG_STATUS { get; set; }
    }
}
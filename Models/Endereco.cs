using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int idEndereco { get; set; }
        public int idCliente { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string siglaEstado { get; set; }
        public string cep { get; set; }

        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
    }
}
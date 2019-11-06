using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("LOGIN")]
    public class ClienteLogin
    {
        [Key]
        public int Id_login { get; set; }
         public string CPF { get; set; }
        public string Senha { get;  set; }
    }
}
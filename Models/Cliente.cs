using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    [Table("LOGIN")]
    public class Cliente
    {
        [Key]
        public int Id_login { get; set; }
         public string CPF { get; set; }
        public string Senha { get; set; }
    }
}
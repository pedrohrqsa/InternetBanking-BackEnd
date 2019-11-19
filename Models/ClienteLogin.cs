using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Login")]
    public class ClienteLogin
    {
        [Key]
        public int idLogin { get; set; }
        public int idCliente { get; set; }
        public string cpf { get; set; }
        public string senha { get; set; }
        
        [ForeignKey("idCliente")]
        public Cliente Cliente {get; set;}
    }
}
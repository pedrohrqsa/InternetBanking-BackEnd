using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Foto")]
    public class Foto
    {
        [Key]
        public int idFoto { get; set; }
        public int idCliente { get; set; }
        public string caminhoFoto { get; set; }
        
        [ForeignKey("idCliente")]
        public Cliente Cliente { get; set; }
    }
}
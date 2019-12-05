using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Agencia")]
    public class Agencia
    {
        [Key]
        public int idAgencia { get; set; }
        public int numeroAgencia { get; set; }
        public ICollection<Conta> Conta { get; set; }
    }
}
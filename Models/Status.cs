using System;
using System.ComponentModel.DataAnnotations.Schema;
using InternetBanking.Models;

namespace InternetBanking_BackEnd.Models
{
    public class Status
    {
        public int IDStatus { get; set; }
        public DateTime dataAlteracao { get; set; }
        public int flagAtivo { get; set; }
        public int numeroConta { get; set; }

        [ForeignKey("numeroConta")]
        public Conta Conta { get; set; }
    }
}
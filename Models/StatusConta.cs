using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using InternetBankingBackEnd.Models;

namespace InternetBanking.Models
{    
    public class StatusConta
    {
        public string cpf { get; set; }
        public string rg { get; set; }
        public DateTime dtNascimento { get; set; }
        public string senhaTransacoes { get; set; }
        public string senhaAcesso { get; set; }
    }
}
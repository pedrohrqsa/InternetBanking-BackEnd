using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetBanking.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string orgaoEmissor { get; set; }
        public DateTime dtNascimento { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string nacionalidade { get; set; }
        public string naturalidade { get; set; }

        public ICollection <ClienteLogin> clienteLogin { get; set; }
        public ICollection <Familiares> Familiares { get; set; }
        public ICollection <Contato> Contatos { get; set; }
        public ICollection <Endereco> Endereco { get; set; }
    }
}
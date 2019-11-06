using InternetBanking.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ClienteDB : DbContext
    {
        public ClienteDB(DbContextOptions<ClienteDB> options) : base(options) { }
        public DbSet <ClienteLogin> ClienteLogin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Familiares> InfoFamiliares { get; set; }
    }
}
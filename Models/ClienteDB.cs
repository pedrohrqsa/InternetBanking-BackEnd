using InternetBanking.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ClienteDB : DbContext
    {
        public ClienteDB(DbContextOptions<ClienteDB> options) : base(options) { }
        public DbSet<ClienteLogin> ClienteLogin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Familiares> Familiares { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(cl => cl.ID_CLIENTE);
            modelBuilder.Entity<ClienteLogin>().HasKey(cl => cl.Id_login);
            modelBuilder.Entity<ClienteLogin>()
                 .HasOne(p => p.Cliente)
                 .WithMany(b => b.clienteLogin);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.ID_CLIENTE);
            modelBuilder.Entity<Familiares>().HasKey(cl => cl.ID_FAMILIARES);
            modelBuilder.Entity<Familiares>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Familiares);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.ID_CLIENTE);
            modelBuilder.Entity<Contato>().HasKey(cl => cl.ID_CONTATO);
            modelBuilder.Entity<Contato>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Contatos);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.ID_CLIENTE);
            modelBuilder.Entity<Endereco>().HasKey(cl => cl.ID_ENDERECO);
            modelBuilder.Entity<Endereco>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Endereco);
        }
    }
}
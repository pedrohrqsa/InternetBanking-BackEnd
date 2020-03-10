using InternetBanking.Models;
using InternetBankingBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ClienteDB : DbContext
    {
        public ClienteDB(DbContextOptions<ClienteDB> options)
            : base(options) { }
            
        public DbSet<ClienteLogin> ClienteLogin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Familiares> Familiares { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Foto> Foto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<ClienteLogin>().HasKey(cl => cl.idLogin);
            modelBuilder.Entity<ClienteLogin>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.clienteLogin);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Familiares>().HasKey(cl => cl.idFamiliares);
            modelBuilder.Entity<Familiares>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Familiares);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Contato>().HasKey(cl => cl.idContato);
            modelBuilder.Entity<Contato>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Contatos);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Endereco>().HasKey(cl => cl.idEndereco);
            modelBuilder.Entity<Endereco>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Endereco);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Conta>().HasKey(cl => cl.numeroConta);
            modelBuilder.Entity<Conta>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Conta);

            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Foto>().HasKey(cl => cl.idFoto);
            modelBuilder.Entity<Foto>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Foto);

        }
    }
}
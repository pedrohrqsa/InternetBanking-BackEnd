using InternetBanking.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDb : DbContext
    {
        public ContaDb(DbContextOptions<ContaDb> options) : base(options) { }

        public DbSet<Conta> Conta { get; set; }
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Banco> Banco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().HasKey(cl => cl.idConta);
            modelBuilder.Entity<Agencia>().HasKey(cl => cl.idAgencia);
            modelBuilder.Entity<Agencia>()
                 .HasOne(p => p.Conta)
                 .WithMany(b => b.Agencia);


            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Familiares>().HasKey(cl => cl.idFamiliares);
            modelBuilder.Entity<Familiares>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Familiares);

            modelBuilder.Entity<Cliente>().HasKey(cl => cl.idCliente);
            modelBuilder.Entity<Familiares>().HasKey(cl => cl.idFamiliares);
            modelBuilder.Entity<Familiares>()
                .HasOne(p => p.Cliente)
                .WithMany(b => b.Familiares);
        }
    }
}
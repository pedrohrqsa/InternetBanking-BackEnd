using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDB : DbContext
    {
        public ContaDB(DbContextOptions<ContaDB> options) : base(options) { }

        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Agencia> Agencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Conta>().HasKey(con => con.idConta);
            modelBuilder.Entity<ContaCorrente>().HasKey(con => con.idContaCorrente);
            modelBuilder.Entity<ContaCorrente>()
                .HasOne(c => c.Conta)
                .WithMany(cc => cc.ContaCorrente);

            modelBuilder.Entity<Conta>().HasKey(con => con.idConta);
            modelBuilder.Entity<Agencia>().HasKey(con => con.idAgencia);
            modelBuilder.Entity<Agencia>()
                .HasOne(c => c.Conta)
                .WithMany(cc => cc.Agencia);
        }
    }
}
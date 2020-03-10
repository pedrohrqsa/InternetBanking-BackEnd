using InternetBankingBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDB : DbContext
    {
        public ContaDB(DbContextOptions<ContaDB> options)
            : base(options) { }

        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Agencia> Agencia { get; set; }

        public DbSet<Status> Status { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Conta>().HasKey(con => con.numeroConta);
            modelBuilder.Entity<Transacao>().HasKey(con => con.idTransacao);
            modelBuilder.Entity<Transacao>()
                .HasOne(c => c.Conta)
                .WithMany(cc => cc.Transacao);

            modelBuilder.Entity<Conta>().HasKey(con => con.numeroConta);
            modelBuilder.Entity<Status>().HasKey(con => con.IDStatus);
            modelBuilder.Entity<Status>()
                .HasOne(c => c.Conta)
                .WithMany(cc => cc.Status);
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDB : DbContext
    {
        public ContaDB(DbContextOptions<ContaDB> options)
            : base(options) { }

        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Agencia> Agencia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Conta>().HasKey(con => con.numeroConta);
            modelBuilder.Entity<Transacao>().HasKey(con => con.idTransacao);
            modelBuilder.Entity<Transacao>()
                .HasOne(c => c.Conta)
                .WithMany(cc => cc.Transacao);

            modelBuilder.Entity<Agencia>().HasKey(con => con.numeroAgencia);
            modelBuilder.Entity<Conta>().HasKey(con => con.numeroConta);
            modelBuilder.Entity<Conta>()
                .HasOne(c => c.Agencia)
                .WithMany(cc => cc.Conta);
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class TransacaoDB : DbContext
    {
        public TransacaoDB(DbContextOptions<TransacaoDB> options) : base(options) { }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Saque> Saque { get; set; }
        public DbSet<Deposito> Deposito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>().HasKey(cl => cl.idTransacao);
            modelBuilder.Entity<Saque>().HasKey(cl => cl.idSaque);
            modelBuilder.Entity<Saque>()
                 .HasOne(p => p.Transacao)
                 .WithMany(b => b.Saque);

            modelBuilder.Entity<Transacao>().HasKey(cl => cl.idTransacao);
            modelBuilder.Entity<Deposito>().HasKey(cl => cl.idDeposito);
            modelBuilder.Entity<Deposito>()
                 .HasOne(p => p.Transacao)
                 .WithMany(b => b.Deposito);
        }
    }
}
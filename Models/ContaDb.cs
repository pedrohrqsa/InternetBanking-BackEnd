using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDB : DbContext
    {
        public ContaDB(DbContextOptions<ContaDB> options) : base(options) { }
        public DbSet<Transacao> Transacao { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Conta>().HasKey(cl => cl.idConta);
            modelBuilder.Entity<Transacao>().HasKey(cl => cl.idTransacao);
            modelBuilder.Entity<Transacao>()
                 .HasOne(p => p.Conta)
                 .WithMany(b => b.Transacao);
        }
    }
}
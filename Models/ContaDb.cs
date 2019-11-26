using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaDB : DbContext
    {
        public ContaDB(DbContextOptions<ContaDB> options) : base(options) { }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Conta>().HasKey(cl => cl.idConta);
            modelBuilder.Entity<ContaCorrente>().HasKey(cl => cl.idContaCorrente);
            modelBuilder.Entity<ContaCorrente>()
                 .HasOne(p => p.Conta)
                 .WithMany(b => b.ContaCorrente);
        }
    }
}
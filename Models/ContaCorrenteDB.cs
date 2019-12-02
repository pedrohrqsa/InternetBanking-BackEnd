using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaCorrenteDB : DbContext
    {
        public ContaCorrenteDB(DbContextOptions<ContaCorrenteDB> options)
            : base(options) { }
            
        public DbSet<ContaCorrente> ContaCorrente {get; set;}
        // public DbSet<Transacao> Transacao { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ContaCorrente>().HasKey(cl => cl.idContaCorrente);
        //     modelBuilder.Entity<Transacao>().HasKey(cl => cl.idTransacao);
        //     modelBuilder.Entity<Transacao>()
        //          .HasOne(p => p.ContaCorrente)
        //          .WithMany(b => b.Transacao);
        // }
    }
}
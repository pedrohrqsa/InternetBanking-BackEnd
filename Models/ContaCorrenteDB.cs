using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ContaCorrenteDB : DbContext
    {
        public ContaCorrenteDB(DbContextOptions<ContaCorrenteDB> options)
            : base(options) { }
            
        public DbSet<ContaCorrente> ContaCorrente {get; set;}
        public DbSet<Transacao> Transacao { get; set; }
    }
}
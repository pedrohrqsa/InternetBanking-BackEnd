using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class TransacaoDB : DbContext
    {
        public TransacaoDB(DbContextOptions<TransacaoDB> options)
            : base(options) { }
            
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Deposito> Deposito { get; set; }
        public DbSet<Saque> Saque { get; set; }
        public DbSet<Transferencia> Transferencia { get; set; }
    }
}
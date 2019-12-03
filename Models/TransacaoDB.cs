using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class TransacaoDB : DbContext
    {
        public TransacaoDB(DbContextOptions<TransacaoDB> options) : base(options) { }
        public DbSet<Transacao> Transacao { get; set; }
    }
}
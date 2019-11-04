using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }
        public DbSet<ClienteLogin> ClienteLogin { get; set; }
        public DbSet<ClienteCad> ClientesCad { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options)
         : base(options)
        { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
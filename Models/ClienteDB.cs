using Microsoft.EntityFrameworkCore;

namespace test.Models
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options) { }
        public DbSet<Cliente> Cliente { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Cliente>()
        //         .HasNoKey();
        // }
    }
}
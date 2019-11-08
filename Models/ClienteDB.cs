using Microsoft.EntityFrameworkCore;

namespace InternetBanking.Models
{
    public class ClienteDB : DbContext
    {
        public ClienteDB(DbContextOptions<ClienteDB> options) : base(options) { }
        public DbSet<ClienteLogin> ClienteLogin { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Familiares> InfoFamiliares { get; set; }
    }
}

        
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<ClienteLogin>()
        //         .HasOne(a => a.Cliente).WithOne(b => b.ID_CLIENTE)
        //         .HasForeignKey<Cliente>(e => e.Id_login);
        //     modelBuilder.Entity<ClienteLogin>().ToTable("CLIENTE");
        //     modelBuilder.Entity<Cliente>().ToTable("CLIENTE");
        // }


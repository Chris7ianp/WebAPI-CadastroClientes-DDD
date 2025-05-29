using CadastroCliente.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Infratruture.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().OwnsOne(c => c.Endereco);
            modelBuilder.Entity<Cliente>().HasIndex(c=> c.Email).IsUnique();
        }
    }
}

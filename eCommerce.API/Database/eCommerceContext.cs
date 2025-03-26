using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Database
{
    public class eCommerceContext : DbContext
    {
        public eCommerceContext(DbContextOptions<eCommerceContext> optios) : base(optios)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecoEntrega { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 2, Nome = "Mercado"},
                new Departamento { Id = 3, Nome = "Moda"},
                new Departamento { Id = 4, Nome = "Moveis"},
                new Departamento { Id = 5, Nome = "Informática"},
                new Departamento { Id = 6, Nome = "Eletrodomésticos"},
                new Departamento { Id = 7, Nome = "Eletroportáteis"},
                new Departamento { Id = 8, Nome = "Beleza"}
                );
        }
    }
}

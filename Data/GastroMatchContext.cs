using Microsoft.EntityFrameworkCore;
using GastroMatch.Admin.Models;

namespace GastroMatch.Admin.Data
{
    public class GastroMatchContext : DbContext
    {
        public GastroMatchContext(DbContextOptions<GastroMatchContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

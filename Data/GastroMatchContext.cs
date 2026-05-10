using Microsoft.EntityFrameworkCore;

namespace GastroMatch.Admin.Data
{
    public class GastroMatchContext : DbContext
    {
        public GastroMatchContext(DbContextOptions<GastroMatchContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

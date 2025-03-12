using Microsoft.EntityFrameworkCore;
using TesteAmbev.Models;

namespace TesteAmbev.Data
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleItem> SaleItems { get; set; }
    }
}

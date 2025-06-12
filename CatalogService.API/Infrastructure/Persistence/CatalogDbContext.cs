using CatalogService.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.API.Infrastructure.Persistence
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

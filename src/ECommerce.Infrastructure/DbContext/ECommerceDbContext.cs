using ECommerce.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.DbContext
{
    public class ECommerceDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}

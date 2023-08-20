using Ecommerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Data
{
    public class EcommerceAppDbContext : DbContext
    {
        public EcommerceAppDbContext(DbContextOptions<EcommerceAppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

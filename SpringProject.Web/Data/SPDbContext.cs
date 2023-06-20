using Microsoft.EntityFrameworkCore;
using SpringProject.Web.Models.Domain;

namespace SpringProject.Web.Data
{
    public class SPDbContext : DbContext
    {
        public SPDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
    }
}

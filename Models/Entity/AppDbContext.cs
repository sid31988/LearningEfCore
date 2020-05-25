using Microsoft.EntityFrameworkCore;

namespace Models.Entity
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        public DbSet<Product> Products { get; set; }
    }
}
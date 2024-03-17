using DataAccess.Configurations;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<FurnitureCategory> FurnitureCategories => Set<FurnitureCategory>();
        public DbSet<Cart> Carts => Set<Cart>();
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FurnitureCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
        }
    }
}

using Alaska.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alaska.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasIndex(t => t.NomCiudad)
                .IsUnique();         

            modelBuilder.Entity<Restaurant>()
                .HasIndex(t => t.NomRestaurante)
                .IsUnique();

            modelBuilder.Entity<Category>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(t => t.Name)
                .IsUnique();

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

    }
}

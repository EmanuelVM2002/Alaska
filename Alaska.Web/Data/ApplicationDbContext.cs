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

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .HasIndex(t => t.NomRestaurante)
                .IsUnique();
        }
        public DbSet<Alaska.Web.Models.City> City { get; set; }
        public DbSet<Alaska.Web.Models.Restaurant> Restaurant { get; set; }
    }
}

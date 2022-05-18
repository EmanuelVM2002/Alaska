using Alaska.Web.Data.Entities;
using Alaska.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alaska.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bill>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<City>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Icy>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Restaurant>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Supplier>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Taste>()
                .HasIndex(t => t.Id)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TypeIcy>()
                .HasIndex(t => t.Id)
                .IsUnique();
        }
        public DbSet<Alaska.Web.Models.Bill> Bill { get; set; }
        public DbSet<Alaska.Web.Models.City> City { get; set; }
        public DbSet<Alaska.Web.Models.Client> Client { get; set; }
        public DbSet<Alaska.Web.Models.Employee> Employee { get; set; }
        public DbSet<Alaska.Web.Models.Icy> Icy { get; set; }
        public DbSet<Alaska.Web.Models.Order> Order { get; set; }
        public DbSet<Alaska.Web.Models.Product> Product { get; set; }
        public DbSet<Alaska.Web.Models.Restaurant> Restaurant { get; set; }
        public DbSet<Alaska.Web.Models.Supplier> Supplier { get; set; }
        public DbSet<Alaska.Web.Models.Taste> Taste { get; set; }
        public DbSet<Alaska.Web.Models.TypeIcy> TypeIcy { get; set; }
    }
}

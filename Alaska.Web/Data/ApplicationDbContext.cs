using Alaska.Web.Models;
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
            modelBuilder.Entity<Client>()
                .HasIndex(t => t.Cedula)
                .IsUnique();
        }
    }
}

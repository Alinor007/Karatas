using KaratasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KaratasAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hash the default admin password
            var adminPasswordHash = BCrypt.Net.BCrypt.HashPassword("adminpass");

            // Seed Admin User
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, // Specify a fixed ID for the admin user
                Username = "Admin",
                Password = adminPasswordHash,
                Role = "Admin"
            });
        }
    }
}

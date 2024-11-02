using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> ApplicationUser { get; set; }

        public virtual DbSet<Office>Offices { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                  new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);

            List<Office> initialOffices = new List<Office>
            {
                new Office { Id = 1, Name = "Chairperson", Description = "CSCS Chairperson" },
                new Office { Id = 2, Name = "Dean", Description = "CICS Dean" },
                new Office { Id = 3, Name = "Extension", Description = "MSU Extension" },
                new Office { Id = 4, Name = "President", Description = "MSU president" }

            };
                    builder.Entity<Office>().HasData(initialOffices);
        }
    }



}

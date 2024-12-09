using DocumentTracker.Models;
using DocumentTrackerWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Emit;

namespace DocumentTrackerWebApi.Data
{
    public class ApplicationDbContext:IdentityDbContext<User>
    {
           public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentApproval> DocumentApprovals { get; set; }
        public virtual DbSet<History> Histories { get; set; }
       public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<User> User { get; set; }
      protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);


            // Configure one-to-many relationship
            builder.Entity<Office>()
                .HasMany(o => o.Users)
                .WithOne(u => u.Office)
                .HasForeignKey(u => u.OfficeId);

            // Configure one-to-many relationship
            builder.Entity<User>()
                .HasMany(o => o.documents)
                .WithOne(u => u.owner)
                .HasForeignKey(u => u.OwnerId);

            List<IdentityRole>roles = new List<IdentityRole>{
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
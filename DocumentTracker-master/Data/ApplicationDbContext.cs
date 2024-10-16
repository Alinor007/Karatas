using DocumentTracker.Models;
using DocumentTrackerWebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
         public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
      protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);
            
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
        }
    }
}
using Microsoft.AspNetCore.Identity;

namespace DocumentTracker.Models
{
    public class Role: IdentityRole
    {

        public string Description { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;

        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int OfficeId {  get; set; }

        [NotMapped]
        public IList<string> Roles { get; set; }
       
        public Office? Office { get; set; }
    }
}

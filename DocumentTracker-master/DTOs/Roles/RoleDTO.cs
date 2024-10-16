using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class RoleDTO
    {
         public string Id { get; set; } // Inherited from IdentityRole
        public string? Name { get; set; } // Inherited from IdentityRole
        public string? Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
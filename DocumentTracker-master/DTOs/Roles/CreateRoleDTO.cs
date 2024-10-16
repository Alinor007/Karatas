using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class CreateRoleDTO
    {
         [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        
        [StringLength(200)]
        public string Description { get; set; }
    }
}
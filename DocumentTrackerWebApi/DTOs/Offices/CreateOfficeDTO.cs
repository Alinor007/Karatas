using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class CreateOfficeDTO
    {
         [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Stage must be a positive integer.")]
        public int Stage { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

       public DateTime Created { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class UpdateUserDTO
    {
         [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public string RoleId { get; set; }
        
        [Required]
        public int OfficeId { get; set; }
        
        // Optionally, you can include fields like Password if you allow updating it
        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
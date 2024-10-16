using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string? UserName { get; set; }
        
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public string? Password { get; set; }


        //[Required]
        //public string Role { get; set; }

        //[ValidateNever]
        //public IEnumerable<SelectListItem> RoleList { get; set; }

        // [Required]
        // [StringLength(100)]
        // public string? Name { get; set; }

        // [Required]
        // [DataType(DataType.Date)]
        // public DateTime BirthDate { get; set; }

        // [Required]
        // public int OfficeId { get; set; }
    }
}
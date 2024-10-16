using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class NewUserDTO
    {
       public string? UserName{get;set;}
       public string? Email{get;set;}

       public string? Token { get;set;}

        //public string? Role { get;set;}

        //[ValidateNever]
        //public IEnumerable<SelectListItem> RoleList { get; set; }

    }
}
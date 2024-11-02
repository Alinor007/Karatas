using DocumentTrackerWebApi.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
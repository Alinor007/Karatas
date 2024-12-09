using DocumentTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class CreateDocumentDTO
    {
        public string Title { get; set; } = string.Empty;

        public string Status { get; set; }

        public string Type { get; set; }
       public string OwnerId { get; set; }

        [Required]
        public DateTime DateCreated { get; init; } 
        public DateTime DateUpdated { get; init; } 


    }
}
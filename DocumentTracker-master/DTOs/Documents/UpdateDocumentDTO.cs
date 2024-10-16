using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class UpdateDocumentDTO
    {
         [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }
        
        public bool? Status { get; set; } // Nullable to allow partial updates
    }
}
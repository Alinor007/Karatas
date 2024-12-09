using DocumentTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class UpdateDocumentDTO
    {
        public string Title { get; set; } = string.Empty;

        public string TrackingNumber { get; init; }

        public string Status { get; set; }

        public DocumentType Type { get; set; }

        public string? OwnerId { get; set; }

        [Required]
        public DateTime DateUpdated { get; set; }


    }
}
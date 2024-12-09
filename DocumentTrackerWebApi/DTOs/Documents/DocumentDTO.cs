using DocumentTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class DocumentDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string TrackingNumber { get; init; } 

        public string? Status { get; set; }

        public string Type { get; set; }

        public string OwnerId { get; set; }

        [Required]
        public DateTime DateCreated { get; init; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

    }
}
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
        //[Required]
        //public string UserId { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;


        public IFormFile? File { get; set; }  // For file upload

        [Required]
        [EnumDataType(typeof(DocumentType))]
        public DocumentType Type { get; set; }


        [Required]
        public string Owner { get; set; } = string.Empty;

        // Defaulting to Pending, assuming it’s the initial state for new documents
        public DocumentStatus Status { get; set; } = DocumentStatus.Pending;


    }
}
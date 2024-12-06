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
        [StringLength(200, MinimumLength = 3)]
        public string? Title { get; set; }

        [EnumDataType(typeof(DocumentType))]
        public DocumentType? Type { get; set; }
        public IFormFile? File { get; set; }  // Allow updating file

        public string? Owner { get; set; }

        [EnumDataType(typeof(DocumentStatus))]
        public DocumentStatus? Status { get; set; }

    }
}
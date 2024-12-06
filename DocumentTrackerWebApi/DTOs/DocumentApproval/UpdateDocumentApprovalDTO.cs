using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentTrackerWebApi.DTOs
{
    public class UpdateDocumentApprovalDTO
    {
        public int? DocumentId { get; set; }

        public int? OfficeId { get; set; }

        [StringLength(1000)]
        public string? Comments { get; set; }

        [StringLength(1000)]
        public string? Remarks { get; set; }

        public DateTime Updated { get; set; } = DateTime.UtcNow;

        [Range(1, int.MaxValue, ErrorMessage = "Stage must be greater than 0.")]
        public int Stage { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentTrackerWebApi.DTOs
{
    public class CreateDocumentApprovalDTO
    {
        [Required]
        public int DocumentId { get; set; }

        [Required]
        public int OfficeId { get; set; }

        [StringLength(1000)]
        public string? Comments { get; set; }

        [StringLength(1000)]
        public string? Remarks { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Stage must be greater than 0.")]
        public int Stage { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}

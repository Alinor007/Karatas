using System;
using System.ComponentModel.DataAnnotations;

namespace DocumentTrackerWebApi.DTOs
{
    public class DocumentApprovalDTO
    {
        public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? OfficeId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Stage must be greater than 0.")]
        public int Stage { get; set; }

        public string? Comments { get; set; }
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}

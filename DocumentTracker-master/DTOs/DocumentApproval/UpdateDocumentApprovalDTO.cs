using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class UpdateDocumentApprovalDTO
    {
        public int? DocumentId { get; set; }
        
        public int? OfficeId { get; set; }
        
        [StringLength(1000)]
        public string Comments { get; set; }
        
        [StringLength(1000)]
        public string Remarks { get; set; }

        public DateTime Updated {  get; set; }
    }
}
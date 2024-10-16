using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class DocumentApprovalDTO
    {
         public int Id { get; set; }
        public int? DocumentId { get; set; }
        public int? OfficeId { get; set; }
        public string Comments { get; set; }
        public string Remarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
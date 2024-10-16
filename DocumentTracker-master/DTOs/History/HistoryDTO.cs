using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class HistoryDTO
    {
         public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; } // For convenience
        public int DocumentApprovalId { get; set; }
        public string Remarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
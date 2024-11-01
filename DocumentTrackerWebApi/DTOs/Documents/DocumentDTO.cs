using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class DocumentDTO
    {
          public int Id { get; set; }
        public string? UserId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string? Name { get; set; }
        public bool Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
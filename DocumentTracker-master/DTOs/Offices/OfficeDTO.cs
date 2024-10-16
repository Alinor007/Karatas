using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class OfficeDTO
    {
          public int Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public int Stage { get; set; } // Consider using an enum
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
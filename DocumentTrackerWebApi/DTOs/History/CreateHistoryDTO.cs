using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.DTOs
{
    public class CreateHistoryDTO
    {
        
        [StringLength(1000)]
        public string Remarks { get; set; }
    }
}
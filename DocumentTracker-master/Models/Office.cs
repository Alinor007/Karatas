using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentTrackerWebApi.Models
{
    public class Office
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public string Name { get; set; } = string.Empty;

        public int Stage { get; set; }  
        public string Description { get; set; }  = string.Empty;

        public DateTime Created { get; set; } = DateTime.UtcNow;
        
        public DateTime Updated { get; set; } = DateTime.UtcNow;
    }
}
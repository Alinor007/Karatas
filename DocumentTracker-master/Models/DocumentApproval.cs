using DocumentTrackerWebApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentTracker.Models
{
    public class DocumentApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        
        public int? DocumentId { get; set; } 
        
        public int? OfficeId { get; set; }
        
        public string Comments { get; set; } = string.Empty;

        public string Remarks { get; set; } = string.Empty;

        public virtual Document? Document { get; set; }
        
        public virtual Office? Office { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}

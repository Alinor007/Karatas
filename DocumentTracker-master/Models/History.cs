using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DocumentTracker.Models
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public  string? UserId { get; set; }

        public int DocumentApprovalId { get; set; }

        public string Remarks { get; set; } = string.Empty;

        public virtual User? User { get; set; }  

        public DocumentApproval DocumentApproval { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

    }
}

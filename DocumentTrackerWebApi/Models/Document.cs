using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentTracker.Models
    {
        public class Document
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Id { get; set; }

            public string? UserId { get; set; }

            public string Name { get; set; } = string.Empty;

            public bool status { get; set; } 

            public virtual User? User { get; set; }

            public DateTime Created { get; set; }

            public DateTime Updated { get; set; }


        }
    }

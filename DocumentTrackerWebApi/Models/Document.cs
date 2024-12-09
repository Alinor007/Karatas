using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentTracker.Models
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string TrackingNumber { get; init; } = GenerateTrackingNumber();

        public string Status { get; set; } = "Draft";

        public string Type { get; set; } = string.Empty ;

        public virtual User? owner { get; set; }
        public string? OwnerId { get; set; }

        [Required]
        public DateTime DateCreated { get; init; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;



        private static string GenerateTrackingNumber()
        {
            DateTime now = DateTime.Now;
            string year = now.ToString("yy");
            string month = now.ToString("MM");
            string day = now.ToString("dd");
            string militaryTime = now.ToString("HH") + now.ToString("mm") + now.ToString("ss");
            string milliseconds = now.ToString("ffff");
            return $"{year}{month}{day}{militaryTime}{milliseconds}";
        }

    }

    public enum DocumentType
    {
        Contract,
        Invoice,
        Report,
        Proposal
    }



 
}

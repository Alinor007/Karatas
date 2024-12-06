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

        public string? UserId { get; set; }

        // New properties for file attachment
        public string? FilePath { get; set; }      // Path to the file
        public string? FileName { get; set; }      // Original file name
        public string? FileType { get; set; }      // MIME type of the file

        public string TrackingNumber { get; init; } = GenerateTrackingNumber();
        public string DocumentNumber { get; init; } = GenerateDocumentNumber();

        [Required]
        [EnumDataType(typeof(DocumentStatus))]
        public DocumentStatus Status { get; set; }

        public string Owner { get; set; } = string.Empty;

        [Required]
        public DateTime DateCreated { get; init; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;

        [Required]
        public string Title { get; set; } = string.Empty;


        public virtual User? User { get; set; }

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

        private static string GenerateDocumentNumber()
        {
            DateTime now = DateTime.Now;
            string year = now.ToString("yyyy");
            string month = now.ToString("MM");
            string day = now.ToString("dd");
            string militaryTime = now.ToString("HH") + now.ToString("mm");
            string milliseconds = now.ToString("ffff");
            return $"{year}-{month}{day}-{militaryTime}-{milliseconds}";
        }
    }

    public enum DocumentType
    {
        Contract,
        Invoice,
        Report,
        Proposal
    }

    public enum DocumentStatus
    {
        Draft,
        Pending,
        Approved,
        Rejected
    }

 
}

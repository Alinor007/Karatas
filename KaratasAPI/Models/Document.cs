namespace KaratasAPI.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; } // Pending, Approved, Declined
        public string CurrentApprover { get; set; } // Chairperson, Dean, President, etc.
        public string Remark { get; set; } // "Fully Approved" or "Declined"
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UserId { get; set; } // Proponent's ID
        public User User { get; set; } // Navigation property
    }
}

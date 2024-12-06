namespace KaratasAPI.DTOs
{
    public class DocumentReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReferenceNumber { get; set; }
        public string Status { get; set; }
        public string CurrentApprover { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

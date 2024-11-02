namespace WebApi.DTO.Auth
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int OfficeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}

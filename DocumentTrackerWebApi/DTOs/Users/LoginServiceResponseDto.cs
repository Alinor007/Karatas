namespace DocumentTrackerWebApi.DTOs.Users
{
    public class LoginServiceResponseDto
    {
        public string NewToken { get; set; }

        // This would be returned to front-end
        public UserInfo UserInfo { get; set; }
    }
}

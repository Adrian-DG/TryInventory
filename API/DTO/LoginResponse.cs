namespace API.DTO
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public bool Status { get; set; }
    }
}
using API.Models;

namespace API.DTO
{
    public class RegisterResponse
    {
        public string Message { get; set; }
        public AppUser User { get; set; }
        public bool Status { get; set; }
    }
}
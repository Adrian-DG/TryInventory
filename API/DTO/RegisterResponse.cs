using API.Models;

namespace API.DTO
{
    public class RegisterResponse
    {
        public AppUser User { get; set; }
        public bool Status { get; set; }
    }
}
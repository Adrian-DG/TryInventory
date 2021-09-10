using API.Models;
using API.Abstraction;

namespace API.Models
{
    public class Employee : IUserData 
    {
        public AppUser User { get; set; }
    }
}
using System;
using API.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser : IUserData
    {
        [Key]
        public Guid UserId { get; set; }      
        [Required]  
        public string  Role { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
      
    }
}
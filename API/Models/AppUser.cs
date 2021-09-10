using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser
    {
        [Key]
        public Guid UserId { get; set; }      
        [Required]  
        public string  Role { get; set; }
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }
      
    }
}
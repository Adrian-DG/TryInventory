using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser
    {
        [Key]
        public Guid UserId { get; set; }      
        public Roles Role { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        
        // Metadata of AppUser 
        public Nullable<Guid> CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
      
    }
}
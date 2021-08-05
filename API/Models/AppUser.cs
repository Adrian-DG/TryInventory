using System;
using API.Abstraction;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser : IUserData
    {
        [Key]
        public Guid UserId { get; set; }        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Company Company { get; set; }
      
    }
}
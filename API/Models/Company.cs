using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; } 
        public ICollection<AppUser> AppUsers { get; set; }   
    }
}
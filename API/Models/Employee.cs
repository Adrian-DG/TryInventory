using API.Models;
using API.Abstraction;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Employee : IUserData 
    {   
        [Key]
        public Guid Id { get; set; }
        public string CreatedBy { get; set; } = null;        
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
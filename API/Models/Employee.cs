using API.Models;
using API.Abstraction;
using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class Employee : IUserData 
    {   
        [Key]
        public Guid Id { get; set; }
        public AppUser User { get; set; }
    }
}
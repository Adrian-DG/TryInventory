using System;
using System.ComponentModel.DataAnnotations;
using API.Abstraction;

namespace API.DTO
{
    public class RegisterDTO : IUserData
    {
        [Required]
        [StringLength(8)]
        public string Password { get; set; }               
    }
}
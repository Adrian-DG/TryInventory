using System;
using System.ComponentModel.DataAnnotations;
using API.Abstraction;

namespace API.DTO
{
    public class RegisterDTO : IUserData
    {
        [Required]
        [MinLength(8)]
        [MaxLength(10)]
        public string Password { get; set; }               
    }
}
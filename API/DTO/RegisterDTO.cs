using System;
using System.ComponentModel.DataAnnotations;
using API.Abstraction;

namespace API.DTO
{
    public class RegisterDTO : IUserData
    {
        [Required]
        [MinLength(6)]
        [MaxLength(8)]
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        [MaxLength(10)]
        public string Password { get; set; }
        public Nullable<Guid> CreatedBy { get; set; }  
        public bool IsAnAdmin { get; set; }             
    }
}
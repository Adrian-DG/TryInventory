using System;
using System.ComponentModel.DataAnnotations;

namespace API.Abstraction
{
    public class IUserData
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Firstname { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string Lastname { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(8)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [DataType(DataType.Date)]
        public DateTime DoB { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }     
    }
}
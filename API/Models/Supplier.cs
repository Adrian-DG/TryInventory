using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Supplier
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public ICollection<Product> Products { get; set; }
        
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
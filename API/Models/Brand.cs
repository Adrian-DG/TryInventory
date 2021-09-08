using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Brand
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
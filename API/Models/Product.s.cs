using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        public Supplier Suppliers { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
    }
}
using System;
using API.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Product : ModelMetadata
    {
        [Key]
        public Brand Brand { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        

    }
}
using System;
using API.Abstraction;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Brand : ModelMetadata
    {
        public ICollection<Product> Products { get; set; }      

    }
}
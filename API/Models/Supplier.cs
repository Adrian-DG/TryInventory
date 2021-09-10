using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Abstraction;

namespace API.Models
{
    public class Supplier : ModelMetadata
    {
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public ICollection<Product> Products { get; set; }        
        
    }
}
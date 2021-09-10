using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models;

namespace API.Abstraction
{
    public class ModelMetadata
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Modified { get; set; }
        public bool Status { get; set; }
    }
}
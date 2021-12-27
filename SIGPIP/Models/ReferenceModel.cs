using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class ReferenceModel
    {
        [Key]
        [Required]
        public Guid studentId { get; set; }
        [Required]
        public string referenceName { get; set; }
        [Required]
        public string referenceAgent { get; set; }
        [Required]
        public int referencePhone { get; set; }
        [Required]
        public string referenceCompany { get; set; }
    }
}

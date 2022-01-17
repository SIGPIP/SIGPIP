using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class ReferenceModel
    {
        [Key]
        [Required]
        public Guid referenceId { get; set; }
        [Required]
        public Guid studentId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string referenceName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string referenceAgent { get; set; }
        [Required]
        [Range(3000000000, 3999999999, ErrorMessage = "Phone number is not valid")]
        public long referencePhone { get; set; }
        [Required]
        public string referenceCompany { get; set; }
    }
}

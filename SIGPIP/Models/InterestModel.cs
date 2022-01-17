using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class InterestModel
    {
        [Key]
        [Required]
        public int interestId { get; set; }
        [Required]
        public Guid studentId { get; set; }
        [Required]
        public string interestName { get; set; }
    }
}

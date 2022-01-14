using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class StudentHabilityModel
    {
        [Key]
        [Required]
        public Guid studentId { get; set; }
        [Key]
        [Required] 
        public int habilityId { get; set; }
    }
}

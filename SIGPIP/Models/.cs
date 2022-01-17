using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class StudentHabilityModel
    {
        [Required]
        public Guid studentId { get; set; }
        [Required] 
        public int habilityId { get; set; }
    }
}

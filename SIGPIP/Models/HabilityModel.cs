using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class HabilityModel
    {
        [Key]
        [Required]
        public int habilityId { get; set; }

        [Required]
        public Guid studentId { get; set; }

        [Required]
        public string habilityName { get; set; }
    }
}

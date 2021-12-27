using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class UniversityModel
    {
        [Key]
        [Required]
        public Guid universityId { get; set; }
        [Required]
        public string universityName { get; set; }
        public string universityCountry { get; set; }
    }
}

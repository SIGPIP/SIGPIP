using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class ExperienceModel
    {
        [Key]
        [Required]
        public Guid studentId { get; set; }
        [Required]
        public string experienceName { get; set; }
        [Required]
        public string experienceEntity { get; set; }
        [Required]
        public string experiencePlace { get; set; }
        [Required]
        public string experienceDescription { get; set; }
        [Required]
        public DateTime experienceStartDate { get; set; }
        [Required]
        public DateTime experienceEndDate { get; set; }

    }
}

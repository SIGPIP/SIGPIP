using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
        public Guid studentId { get; set; }
        [Required]
        public string studentNames { get; set; }
        [Required]
        public string studentLastNames { get; set; }
        [Required]
        public string studentEmail { get; set; }
        public string studentBio { get; set; }
        [Required]
        public string studentCareer { get; set; }
        [Required]
        public int studentSemester { get; set; }
        [Required]
        public string studentCountry { get; set; }
    }
}

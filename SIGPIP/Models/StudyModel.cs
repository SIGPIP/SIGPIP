using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class StudyModel
    {
        [Key]
        [Required]
        public Guid studyId { get; set; }
        [Required]
        public int studyYear { get; set; }
        [Required]
        public string studyGrade { get; set; }
        [Required]
        public string studyName { get; set; }
        [Required]
        public string studyPlace { get; set; }
        public string studyCity { get; set; }
        public string studyCountry { get; set; }

    }
}

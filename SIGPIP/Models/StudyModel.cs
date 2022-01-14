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
        public Guid studentId { get;set; }
        [Required(ErrorMessage = "Year required")]
        public int studyYear { get; set; }
        [Required(ErrorMessage = "Grade required")]
        public string studyGrade { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string studyName { get; set; }
        [Required(ErrorMessage = "Place required")]
        public string studyPlace { get; set; }
        public string studyCity { get; set; }
        public string studyCountry { get; set; }

    }
}

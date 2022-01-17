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
        [Range(1950, 2022, ErrorMessage = "Year is not valid")]
        public int studyYear { get; set; }
        [Required(ErrorMessage = "Grade required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studyGrade { get; set; }
        [Required(ErrorMessage = "Name required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studyName { get; set; }
        [Required(ErrorMessage = "Place required")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studyPlace { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studyCity { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studyCountry { get; set; }

    }
}

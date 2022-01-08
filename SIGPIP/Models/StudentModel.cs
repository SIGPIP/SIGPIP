
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIGPIP.Models
{
    public class StudentModel
    {
        [Key]
        public Guid studentId { get; set; }
        [Required(ErrorMessage = "Name required")]
        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studentNames { get; set; }
        [Required(ErrorMessage = "Last name required")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studentLastNames { get; set; }
        [Required(ErrorMessage = "Email required")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string studentEmail { get; set; }
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password needs to have a minimum of 8 characters")]
        [Display(Name = "Password")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string studentPassword { get; set; }

        [Required(ErrorMessage = "Confirm password required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("studentPassword", ErrorMessage = "Password and confirmation password must match")]
        public string studentConfirmPassword { get; set; }

        [Display(Name = "Bio")]
        public string studentBio { get; set; }
        [Required(ErrorMessage = "Career required")]
        [Display(Name = "Career")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studentCareer { get; set; }
        [Required(ErrorMessage = "Semester required")]
        [Range(1, 15, ErrorMessage = "Semester must be between 1 and 15")]
        [Display(Name = "Semester")]
        public int studentSemester { get; set; }
        [Required(ErrorMessage = "Country required")]
        [Display(Name = "Country")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u017F\s\00F1\00D1]*$", ErrorMessage = "First character must be in capital letters, numbers are not accepted")]
        public string studentCountry { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class PendingProjectModel
    {
        [Key]
        [Required]
        public Guid pendingProjectId { get; set; }
        [Required]
        public string pendingProjectName { get; set; }
        [Required]
        public string pendingProjectDescription { get; set; }
    }
}

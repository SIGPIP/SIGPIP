using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class ProjectModel
    {
        [Key]
        [Required]
        public Guid projectId { get; set; }
        [Required]
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        [Required]
        public string projectRepoLink { get; set; }
        public string projectLink { get; set; }
        public string projectImageUrl { get; set; }
        [Required]
        public Guid projectZipId { get; set; }
        [Required]
        public string projectFramework { get; set; }
    }
}

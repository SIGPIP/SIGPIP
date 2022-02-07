using Microsoft.AspNetCore.Http;

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
        public Guid studentId { get; set; }
        [Required]
        public string projectName { get; set; }
        public byte[] projectImageData { get; set; }
        public string projectDescription { get; set; }
        [Required]
        public string projectRepoLink { get; set; }
        public string projectLink { get; set; }
        [Required]
        public byte[] projectZipData { get; set; }
        [Required]
        public string projectFramework { get; set; }
        [Required]
        public string projectLanguages { get; set; }
        [Required]
        public DateTime projectUploadDate { get; set; }
        [Required]
        public DateTime projectLastUpdate { get; set; }
    }
}

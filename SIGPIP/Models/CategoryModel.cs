using System;
using System.ComponentModel.DataAnnotations;

namespace SIGPIP.Models
{
    public class CategoryModel
    {
        [Key]
        [Required]
        public Guid categoryId { get; set; }
        [Required]
        public string categoryName { get; set; }
        public Guid categoryParentId { get; set; }
        public Guid subCategoryId { get; set; }
    }
}

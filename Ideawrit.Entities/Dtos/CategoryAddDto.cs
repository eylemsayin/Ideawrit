using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ideawrit.Entities.Dtos
{
    public class CategoryAddDto
    {
        [DisplayName("Category Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(70, ErrorMessage = "{0} {1} cannot be greater than a character")]
        [MinLength(3, ErrorMessage = "{0} {1} cannot be less than one character")]
        public string Name { get; set; }
        [DisplayName("Category Description")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(500, ErrorMessage = "{0} {1} cannot be greater than a character")]
        [MinLength(3, ErrorMessage = "{0} {1} cannot be less than one character")]
        public string Description { get; set; }
        [DisplayName("Category private note field")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(500, ErrorMessage = "{0} {1} cannot be greater than a character")]
        [MinLength(3, ErrorMessage = "{0} {1} cannot be less than one character")]
        public string Note { get; set; }
        [DisplayName("Is the category active?")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public bool IsActive { get; set; }
    }
}

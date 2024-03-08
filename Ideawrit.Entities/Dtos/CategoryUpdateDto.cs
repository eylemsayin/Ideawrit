using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideawrit.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }

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
        [DisplayName("Was it deleted??")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        public bool IsDeleted { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos.Author
{
    public class AuthorAddDto
    {

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
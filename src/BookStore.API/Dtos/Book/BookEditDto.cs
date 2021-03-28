﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos.Book
{
    public class BookEditDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(150, ErrorMessage = "The field {0} must be between {2} and {1} characters", MinimumLength = 2)]
        public string Name { get; set; }
        
        public List<int> AuthorIds { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        public double Value { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
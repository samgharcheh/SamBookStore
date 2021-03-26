using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos.Author
{
    public class AuthorResultDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
using System;
using System.Collections.Generic;
using BookStore.API.Dtos.Author;

namespace BookStore.API.Dtos.Book
{
    public class BookResultDto
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string Name { get; set; }

        public List<int> AuthorIds { get; set; }
        public List<string> AuthorName { get; set; }

        public string Description { get; set; }

        public double Value { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
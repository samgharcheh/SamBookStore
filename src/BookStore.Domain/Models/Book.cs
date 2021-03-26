using System;
using System.Collections.Generic;

namespace BookStore.Domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }

        /* EF Relation */
        public Category Category { get; set; }
        public virtual List<Author> Authors { get; set; }
    }
}
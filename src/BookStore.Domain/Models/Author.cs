using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Models
{
    public class Author : Entity
    {
        public string Name { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}


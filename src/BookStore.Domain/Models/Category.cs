using System.Collections.Generic;

namespace BookStore.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }

        /* EF Relations */
        public List<Book> Books { get; set; }
    }
}
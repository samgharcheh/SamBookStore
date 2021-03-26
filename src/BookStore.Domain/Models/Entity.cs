using System;

namespace BookStore.Domain.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            CreatedDateTimeUtc = DateTime.UtcNow;
            IsActive = true;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTimeUtc { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
using System;
namespace Order.Domain.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

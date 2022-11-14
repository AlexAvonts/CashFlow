using System;

namespace CashFlow.Domain.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }   
        public bool IsDeleted { get; set; }
    }
}

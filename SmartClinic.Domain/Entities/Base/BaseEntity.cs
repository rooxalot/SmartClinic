using System;

namespace SmartClinic.Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
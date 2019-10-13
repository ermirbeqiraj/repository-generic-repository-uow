using System;

namespace Domain
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime Created { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

using System;

namespace Domain
{
    public class Service : EntityBase
    {
        public string Title { get; set; }
        public long Odometer { get; set; }
        public string Description { get; set; }
        public Guid CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}

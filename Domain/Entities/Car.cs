using System;
using System.Collections.Generic;

namespace Domain
{
    public class Car : EntityBase
    {
        public Car()
        {
            Services = new HashSet<Service>();
        }
        public string VIN { get; set; }
        public string Model { get; set; }
        public Guid OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual ICollection<Service> Services { get; set; }
    }
}

using System.Collections.Generic;

namespace Domain
{
    public class Owner : EntityBase
    {
        public Owner()
        {
            Cars = new HashSet<Car>();
        }
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}

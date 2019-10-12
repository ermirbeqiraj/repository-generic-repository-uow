using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Core
{
    public interface IOwnerRepository : IDisposable
    {
        IEnumerable<Owner> GetAll();
        Owner Get(Guid Id);
        void Insert(Owner model);
        void Update(Owner model);
        void Delete(Owner model);
        void Save();
    }
}

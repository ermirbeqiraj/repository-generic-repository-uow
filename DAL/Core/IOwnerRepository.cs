using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryPattern.DAL.Core
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner Get(Guid Id);
        void Insert(Owner model);
        void Update(Owner model);
        void Delete(Owner model);
    }
}

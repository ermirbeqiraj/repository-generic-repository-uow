using Domain;
using System;
using System.Collections.Generic;

namespace RepositoryPattern.DAL.Core
{
    public interface IServiceRepository
    {
        IEnumerable<Service> GetAll();
        Service Get(Guid Id);
        void Insert(Service model);
        void Update(Service model);
        void Delete(Service model);
    }
}

using Domain;
using GenericRepositoryPattern.DAL.Core;

namespace GenericRepositoryPattern.DAL
{
    public interface IUnitOfWork
    {
        IRepository<Car> CarRepository { get; }
        IRepository<Owner> OwnerRepository { get; }
        IRepository<Service> ServiceRepository { get; }

        void Commit();
    }
}

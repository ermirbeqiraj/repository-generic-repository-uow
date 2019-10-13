using RepositoryPattern.DAL.Core;

namespace RepositoryPattern.DAL
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IOwnerRepository OwnerRepository { get; }
        IServiceRepository ServiceRepository { get; }

        void Commit();
    }
}

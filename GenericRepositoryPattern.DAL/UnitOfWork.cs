using Domain;
using Domain.EF.SqlServer;
using GenericRepositoryPattern.DAL.Core;
using GenericRepositoryPattern.DAL.Persistence;
using System;

namespace GenericRepositoryPattern.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;

        private IRepository<Car> _carRepository;
        private IRepository<Owner> _ownerRepository;
        private IRepository<Service> _serviceRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepository<Car> CarRepository
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new Repository<Car>(_context);

                return _carRepository;
            }
        }

        public IRepository<Owner> OwnerRepository
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new Repository<Owner>(_context);

                return _ownerRepository;
            }
        }

        public IRepository<Service> ServiceRepository
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new Repository<Service>(_context);

                return _serviceRepository;
            }
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

using DAL.Core;
using DAL.Persistence;
using Domain.EF.SqlServer;
using System;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ICarRepository _carRepository;
        private IOwnerRepository _ownerRepository;
        private IServiceRepository _serviceRepository;
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICarRepository CarRepository
        {
            get
            {
                if (_carRepository == null)
                    _carRepository = new CarRepository(_context);

                return _carRepository;
            }
        }

        public IOwnerRepository OwnerRepository
        {
            get
            {
                if (_ownerRepository == null)
                    _ownerRepository = new OwnerRepository(_context);

                return _ownerRepository;
            }
        }

        public IServiceRepository ServiceRepository
        {
            get
            {
                if (_serviceRepository == null)
                    _serviceRepository = new ServiceRepository(_context);

                return _serviceRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        #region Dispose db con
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

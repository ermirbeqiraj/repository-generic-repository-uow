using DAL.Core;
using Domain;
using Domain.EF.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Persistence
{
    public class ServiceRepository : IServiceRepository, IDisposable
    {
        private readonly ApplicationDbContext context;
        
        public ServiceRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        
        public Service Get(Guid Id)
        {
            return context.Services.Find(Id);
        }

        public IEnumerable<Service> GetAll()
        {
            return context.Services.ToList();
        }

        public void Insert(Service model)
        {
            context.Services.Add(model);
        }

        public void Delete(Service model)
        {
            context.Services.Remove(model);
        }

        public void Update(Service model)
        {
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        #region Dispose db con
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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

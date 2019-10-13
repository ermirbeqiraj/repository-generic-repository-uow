using RepositoryPattern.DAL.Core;
using Domain;
using Domain.EF.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryPattern.DAL.Persistence
{
    public class OwnerRepository : IOwnerRepository, IDisposable
    {
        private readonly ApplicationDbContext context;
        public OwnerRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public Owner Get(Guid Id)
        {
            return context.Owners.Find(Id);
        }

        public IEnumerable<Owner> GetAll()
        {
            return context.Owners.ToList();
        }

        public void Insert(Owner model)
        {
            context.Owners.Add(model);
        }

        public void Update(Owner model)
        {
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Owner model)
        {
            context.Owners.Remove(model);
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

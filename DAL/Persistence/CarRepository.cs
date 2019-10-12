using DAL.Core;
using Domain;
using Domain.EF.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Persistence
{
    public class CarRepository : ICarRepository, IDisposable
    {
        private readonly ApplicationDbContext context;
        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public Car Get(Guid Id)
        {
            return context.Cars.Find(Id);
        }

        public IEnumerable<Car> GetAll()
        {
            return context.Cars.ToList();
        }

        public void Insert(Car model)
        {
            context.Cars.Add(model);
        }
        
        public void Update(Car model)
        {
            context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(Car model)
        {
            context.Cars.Remove(model);
        }

        public void Save()
        {
            context.SaveChanges();
        }



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
    }
}

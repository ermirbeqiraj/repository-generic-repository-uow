using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GenericRepositoryPattern.DAL.Core
{
    public interface IRepository<T> where T : EntityBase
    {
        T Get(Guid id);

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string[] include = null
            );

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

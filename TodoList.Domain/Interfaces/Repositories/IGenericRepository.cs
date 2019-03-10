using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TodoList.Domain.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);
        T FindOne(Expression<Func<T, bool>> predicate);
        IQueryable<T> Query(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
    }
}

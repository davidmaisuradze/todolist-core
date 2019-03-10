using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using TodoList.Domain.Entities.Base;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Data.Repositories
{
    public class GenericRepository<T> : IDisposable, IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
        {
            var query = predicate != null ? _dbSet.Where(predicate) : _dbSet;
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(Expression<Func<T, bool>> predicate)
        {
            _dbSet.RemoveRange(_dbSet.Where(predicate));
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}

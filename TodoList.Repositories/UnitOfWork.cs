using System;
using Microsoft.EntityFrameworkCore.Storage;
using TodoList.Data.Repositories;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Interfaces.Repositories;
using TodoList.Repositories.Database;

namespace TbcIns.Services.Claims.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoListContext _dbContext;

        public UnitOfWork(TodoListContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Repos
        public IGenericRepository<UserEntity> Users => new GenericRepository<UserEntity>(_dbContext);

        public IGenericRepository<TaskEntity> Tasks => new GenericRepository<TaskEntity>(_dbContext);
        #endregion

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0 ? true : false;
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}

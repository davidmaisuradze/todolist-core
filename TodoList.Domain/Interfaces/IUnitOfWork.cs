using System;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces.Repositories;

namespace TodoList.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repos

        IGenericRepository<UserEntity> Users { get; }
        IGenericRepository<TaskEntity> Tasks { get; }

        #endregion

        bool Save();
    }
}

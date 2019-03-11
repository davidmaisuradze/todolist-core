using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Entities;

namespace TodoList.Data.Database
{
    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
    }
}

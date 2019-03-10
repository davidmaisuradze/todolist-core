using System.Collections.Generic;
using TodoList.Domain.Models.Task;

namespace TodoList.Domain.Interfaces.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetTasks();
        IEnumerable<TaskModel> CreateTask(CreateTaskRequest model);
        IEnumerable<TaskModel> UpdateTask(UpdateTaskRequest model);
        IEnumerable<TaskModel> AssignTaskToUser(AssignTaskToUserRequest model);
        IEnumerable<TaskModel> DeleteTask(int id);
    }
}

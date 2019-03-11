using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Models.Task;

namespace TodoList.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<TaskModel> GetTasks()
        {
            var result = _unitOfWork.Tasks.Query(includes: x => x.User)
                .Select(x => new TaskModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    DueDate = x.DueDate,
                    Status = x.Status,
                    Assignee = new Assignee
                    {
                        Email = x.User.Email
                    }
                }).ToList();

            return result;
        }

        public IEnumerable<TaskModel> CreateTask(CreateTaskRequest model)
        {
            var checkTask = _unitOfWork.Tasks.FindOne(x => x.Title == model.Title);
            if (checkTask != null)
            {
                throw new Exception("task already exists");
            }

            var taskEntity = new TaskEntity
            {
                Title = model.Title,
                Description = model.Description,
                DueDate = model.DueDate,
                Status = model.Status
            };

            _unitOfWork.Tasks.Add(taskEntity);
            _unitOfWork.Save();

            return GetTasks();
        }

        public IEnumerable<TaskModel> UpdateTask(UpdateTaskRequest model)
        {
            var task = _unitOfWork.Tasks.GetById(model.Id);
            if (task == null)
            {
                throw new Exception("task not found");
            }

            task.Title = model.Title;
            task.Description = model.Description;
            task.DueDate = model.DueDate;
            task.Status = model.Status;

            _unitOfWork.Tasks.Update(task);
            _unitOfWork.Save();

            return GetTasks();
        }

        public IEnumerable<TaskModel> AssignTaskToUser(AssignTaskToUserRequest model)
        {
            var user = _unitOfWork.Users.GetById(model.AssigneeId);
            if (user == null)
            {
                throw new Exception("user not found");
            }

            var task = _unitOfWork.Tasks.GetById(model.TaskId);
            if (task == null)
            {
                throw new Exception("task not found");
            }

            task.UserId = model.AssigneeId;
            _unitOfWork.Tasks.Update(task);
            _unitOfWork.Save();

            return GetTasks();
        }

        public IEnumerable<TaskModel> DeleteTask(int id)
        {
            var task = _unitOfWork.Tasks.GetById(id);
            if (task == null)
            {
                throw new Exception("task not found");
            }

            _unitOfWork.Tasks.Delete(task);
            _unitOfWork.Save();

            return GetTasks();
        }
    }
}

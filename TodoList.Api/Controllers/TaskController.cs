using Microsoft.AspNetCore.Mvc;
using System;
using TodoList.Domain.Interfaces.Services;
using TodoList.Domain.Models.Task;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _taskService.GetTasks();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTaskRequest model)
        {
            var result = _taskService.CreateTask(model);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateTaskRequest model)
        {
            var result = _taskService.UpdateTask(model);
            return Ok(result);
        }

        [HttpPut("assignTask")]
        public IActionResult AssignTask([FromBody] AssignTaskToUserRequest model)
        {
            var result = _taskService.AssignTaskToUser(model);
            return Ok(result);
        }

        [HttpDelete(":taskId")]
        public IActionResult Delete(int taskId)
        {
            var result = _taskService.DeleteTask(taskId);
            return Ok(result);
        }
    }
}

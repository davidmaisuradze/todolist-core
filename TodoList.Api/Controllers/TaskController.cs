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
            try
            {
                var result = _taskService.GetTasks();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateTaskRequest model)
        {
            try
            {
                var result = _taskService.CreateTask(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateTaskRequest model)
        {
            try
            {
                var result = _taskService.UpdateTask(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("assignTask")]
        public IActionResult AssignTask([FromBody] AssignTaskToUserRequest model)
        {
            try
            {
                var result = _taskService.AssignTaskToUser(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete(":taskId")]
        public IActionResult Delete(int taskId)
        {
            try
            {
                var result = _taskService.DeleteTask(taskId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

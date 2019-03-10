using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Domain.Models.Task
{
    public class AssignTaskToUserRequest
    {
        [JsonProperty("taskId")]
        [Required]
        public int TaskId { get; set; }

        [JsonProperty("assigneeId")]
        [Required]
        public int AssigneeId { get; set; }
    }
}

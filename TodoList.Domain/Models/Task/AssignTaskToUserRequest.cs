using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

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

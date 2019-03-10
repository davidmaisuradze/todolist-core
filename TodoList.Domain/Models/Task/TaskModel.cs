using Newtonsoft.Json;
using System;

namespace TodoList.Domain.Models.Task
{
    public class TaskModel
    {
        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        public DateTime DueDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("assignee")]
        public Assignee Assignee { get; set; }
    }

    public class Assignee
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Models.Task
{
    public class UpdateTaskRequest
    {
        [JsonProperty("_id")]
        [Required]

        public int Id { get; set; }

        [JsonProperty("title")]
        [Required]
        [MaxLength(250, ErrorMessage = "max length 250")]

        public string Title { get; set; }

        [JsonProperty("description")]
        [Required]
        [MaxLength(1000, ErrorMessage = "max length 250")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        [Required]
        public DateTime DueDate { get; set; }

        [JsonProperty("status")]
        [Required]
        [MaxLength(50, ErrorMessage = "max length 250")]
        public string Status { get; set; }
    }
}

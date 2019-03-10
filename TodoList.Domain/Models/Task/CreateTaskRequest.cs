using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Domain.Models.Task
{
    public class CreateTaskRequest
    {
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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TodoList.Domain.Models.User
{
    public class LoginRequest
    {
        [JsonProperty("email")]
        [Required]

        public string Email { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }
    }
}

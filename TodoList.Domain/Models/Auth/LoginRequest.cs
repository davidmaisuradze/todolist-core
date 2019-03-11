using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Models.Auth
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

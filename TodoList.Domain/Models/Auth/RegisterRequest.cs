using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Domain.Models.Auth
{
    public class RegisterRequest
    {
        [JsonProperty("email")]
        [Required]
        [EmailAddress(ErrorMessage = "email address invalid format")]

        public string Email { get; set; }

        [JsonProperty("password")]
        [Required]
        [MinLength(6, ErrorMessage = "minimum 6 characters")]
        public string Password { get; set; }

        [JsonProperty("firstName")]
        [Required]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        [Required]
        public string LastName { get; set; }
    }
}

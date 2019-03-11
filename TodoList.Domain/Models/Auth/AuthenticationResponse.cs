using Newtonsoft.Json;

namespace TodoList.Domain.Models.Auth
{
    public class AuthenticationResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("user")]
        public AuthenticatedUser User { get; set; }


    }

    public class AuthenticatedUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }
}

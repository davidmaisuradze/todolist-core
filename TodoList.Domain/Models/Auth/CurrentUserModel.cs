using Newtonsoft.Json;

namespace TodoList.Domain.Models.Auth
{
    public class CurrentUserModel
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

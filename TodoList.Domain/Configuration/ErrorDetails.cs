using Newtonsoft.Json;

namespace TodoList.Domain.Configuration
{
    public class ErrorDetails
    {
        [JsonProperty("status")]
        public int StatusCode { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

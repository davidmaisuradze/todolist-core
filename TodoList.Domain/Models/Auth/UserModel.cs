﻿using Newtonsoft.Json;

namespace TodoList.Domain.Models.Auth
{
    public class UserModel
    {

        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}

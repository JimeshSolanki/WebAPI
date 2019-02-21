using Newtonsoft.Json;
using System;

namespace WebAPI.Models
{
    public class Request
    {
        public string Id { get; set; }
    }

    public class Response
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "obj")]
        public Object Obj { get; set; }
    }
}
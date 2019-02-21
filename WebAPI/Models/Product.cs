using Newtonsoft.Json;
using System;

namespace WebAPI.Models
{
    public class Product
    {
        [JsonProperty(PropertyName = "Id")]
        public int? Id { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "Quantity")]
        public Decimal? Qty { get; set; }

        [JsonProperty(PropertyName = "Price")]
        public Decimal? Price { get; set; }
    }
}
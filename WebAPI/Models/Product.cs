using System;

namespace WebAPI.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public Decimal? Quantity { get; set; }
        public Decimal? Price { get; set; }
    }
}
using System;

namespace DataLayer
{
    public partial class Product
    {
        public int id { get; set; }

        public string productname { get; set; }

        public Nullable<decimal> qty { get; set; }

        public Nullable<decimal> price { get; set; }
    }
}

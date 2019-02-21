using System;

namespace DataLayer
{
    public partial class Product
    {
        public int id { get; set; }

        public string productname { get; set; }

        public Decimal? qty { get; set; }

        public Decimal? price { get; set; }
    }
}

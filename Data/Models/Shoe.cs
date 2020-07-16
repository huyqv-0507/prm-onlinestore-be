using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public string ShoesName { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }

        public Brand Brand { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

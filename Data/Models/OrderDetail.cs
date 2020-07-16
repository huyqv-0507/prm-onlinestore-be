using System;
namespace Data.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string Username { get; set; }
        public int ShoeId { get; set; }
        public decimal Price { get; set; }

        public Shoe Shoe { get; set; }
        public Order Order { get; set; }
    }
}

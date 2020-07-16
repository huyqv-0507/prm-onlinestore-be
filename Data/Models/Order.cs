using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime DateCreated { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public string Username { get; set; }

        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

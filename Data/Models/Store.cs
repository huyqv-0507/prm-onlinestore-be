using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Address { get; set; }

        public ICollection<User> Users { get; set; }
    }
}

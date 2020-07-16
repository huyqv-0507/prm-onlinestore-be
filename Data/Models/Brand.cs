using System.Collections.Generic;

namespace Data.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public ICollection<Shoe> Shoes { get; set; }

    }
}

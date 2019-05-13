using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public string Colors { get; set; }  // available colors
        public string Sizes { get; set; }  // available sizes
    }
}

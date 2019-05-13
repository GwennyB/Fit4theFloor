using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string BuyerEmail { get; set; }
        public string ShipAddress { get; set; }
        public string PayPalConf { get; set; }
        public decimal ShippingFee { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime? Closed { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
    }
}

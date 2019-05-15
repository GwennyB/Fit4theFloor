using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class ClientMessage
    {
        public int ID { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime Sent { get; set; }
        public DateTime? Read { get; set; }
        public string Contents { get; set; }
    }
}

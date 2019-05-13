using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class WeighIn
    {
        public int ID { get; set; }
        public string UserEmail { get; set; }
        public DateTime Date { get; set; }
        public int Height { get; set; }  // inches
        public int Weight { get; set; }  // pounds
        public int Chest { get; set; }  // inches
        public int Waist { get; set; }  // inches
        public int Hips { get; set; }  // inches
        public int HeartRate { get; set; }  // BPM
    }
}

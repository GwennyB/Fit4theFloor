using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class BlogPost
    {
        public int ID { get; set; }
        public PostCategory Category { get; set; }
        public DateTime Date { get; set; }
        public string Images { get; set; }
        public string Videos { get; set; }
        public string Discussion { get; set; }
    }

    public enum PostCategory
    {
        fitness,
        nutrition,
        life
    }
}

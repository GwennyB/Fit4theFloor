using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fit4TheFloor.Models
{
    public class Purchase
    {
        public int ID { get; set; }
        public int CartID { get; set; }
        public int ProductID { get; set; }
        public decimal ExtPrice { get; set; }
        public int Qty { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }
        public int PrintID { get; set; }
        public Color PrintColor { get; set; }
        public DateTime? Closed { get; set; }

        // navigation properties
        public Cart Cart { get; set; }
        public Product Product { get; set; }
        public Print Print { get; set; }
    }


    public enum Size
    {
        XXS,
        XS,
        S,
        M,
        L,
        XL,
        XXL,
        XXXL
    }

    public enum Color
    {
        blue,
        yellow,
        red,
        gray,
        white,
        black
    }
}

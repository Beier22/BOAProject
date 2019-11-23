using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public enum Size
    {
        S, M, L, XL, XXL
    }

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public double Price { get; set; }
        public Size Size { get; set; }
        public int AvailableQuantity { get; set; }
        public Order Order { get; set; }
        public double DiscountPrice { get; set; }
        public Collection Collection { get; set; }

        public string Description { get; set; }
    }
}

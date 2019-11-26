using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class ProductQuantity
    {
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

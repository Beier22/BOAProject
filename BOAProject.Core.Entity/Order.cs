using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class Order
    {
        public int ID { get; set; }
        public User User { get; set; }
        public double Total { get; set; }
        public Address Address { get; set; }
        public List<Product> Products { get; set; }
    }
}

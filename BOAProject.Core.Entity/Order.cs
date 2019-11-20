using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public double Total { get; set; }
        public int AddressID { get; set; }
    }
}

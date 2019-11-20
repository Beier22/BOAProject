using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class Address
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
    }
}

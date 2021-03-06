﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.Entity
{
    public class SizeQuantity
    {
        public int ID { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }

        public SizeQuantity(Size size, int quantity)
        {
            Size = size;
            if (quantity >= 0)
                Quantity = quantity;
            else
                throw new Exception("Minimal quantity is 0.");
        }

    }
  
}

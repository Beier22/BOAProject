using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices.Filtering
{
    public enum OrderBy { asc = 1 , dsc = 2 , col = 3 }
    
    public class Filter
    {
        public int ItemsPrPage { get; set; }
        public int CurrentPage { get; set; }
        public OrderBy Order { get; set; }
        


    }
}

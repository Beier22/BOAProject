using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices.Filtering
{
    public enum Price { asc, dsc }

    public class Filter
    {
        public int ItemsPrPage { get; set; }
        public int CurrentPage { get; set; }
        public Price Price { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Collection { get; set; }

    }
}

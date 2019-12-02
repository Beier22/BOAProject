using System;
using System.Collections.Generic;
using System.Text;

namespace BOAProject.Core.DomainServices.Filtering
{
    public enum OrderBy { asc, dsc , col }

    public class Filter
    {
        public int ItemsPrPage { get; set; }
        public int CurrentPage { get; set; }
        public OrderBy Order { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public string Collection { get; set; }

    }
}

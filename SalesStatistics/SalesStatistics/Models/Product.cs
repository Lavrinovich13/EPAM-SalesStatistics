using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("{0}", Name);
        }
    }
}
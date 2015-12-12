using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Sum { get; set; }

        public Client Client { get; set; }
        public Manager Manager { get; set; }
        public Product Product { get; set; }
    }
}
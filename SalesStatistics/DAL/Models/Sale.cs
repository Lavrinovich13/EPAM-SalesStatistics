﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
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

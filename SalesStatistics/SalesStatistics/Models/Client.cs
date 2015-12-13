﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", LastName, FirstName);
        }

        public string FullName
        {
            get
            {
                return ToString();
            }
        }
    }
}
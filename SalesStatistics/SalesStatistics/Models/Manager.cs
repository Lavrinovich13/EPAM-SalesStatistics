﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [DataType(DataType.Text, ErrorMessage = "It is a text field.")]
        public string LastName { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", LastName);
        }
    }
}
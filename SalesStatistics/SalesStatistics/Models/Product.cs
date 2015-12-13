using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [DataType(DataType.Text, ErrorMessage = "It is a text field.")]
        public string Name { get; set; }
        public override string ToString()
        {
            return String.Format("{0}", Name);
        }
    }
}
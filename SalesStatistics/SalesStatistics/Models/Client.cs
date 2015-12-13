using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [DataType(DataType.Text, ErrorMessage = "It is a text field.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [DataType(DataType.Text, ErrorMessage = "It is a text field.")]
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
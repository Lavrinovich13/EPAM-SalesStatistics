using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesStatistics.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
    }
}
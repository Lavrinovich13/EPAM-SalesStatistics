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

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "It is a date field.")]
        public System.DateTime Date { get; set; }

        [Required(ErrorMessage = "Sum is required.")]
        [DataType(DataType.Currency, ErrorMessage = "It is a currency field.")]
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Client is required.")]
        public Client Client { get; set; }

        [Required(ErrorMessage = "Manager is required.")]
        public Manager Manager { get; set; }

        [Required(ErrorMessage = "Product is required.")]
        public Product Product { get; set; }
    }
}
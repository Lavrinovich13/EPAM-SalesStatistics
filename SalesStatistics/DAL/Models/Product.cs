using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Product : IEquatable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Equals(Product other)
        {
            return Name == other.Name;
        }


    }
}

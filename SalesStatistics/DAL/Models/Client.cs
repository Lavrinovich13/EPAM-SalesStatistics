﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client : IEquatable<Client>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public bool Equals(Client other)
        {
            return LastName == other.LastName
                && FirstName == other.FirstName;
        }
    }
}

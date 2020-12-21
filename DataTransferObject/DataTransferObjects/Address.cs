using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DataTransferObjects
{
    public class Address
    {
        public int Id;
        public string City;
        public string Street;

        public Address() { }

        public Address(string city, string street)
        {
            this.City = city;
            this.Street = street;
        }

    }
}

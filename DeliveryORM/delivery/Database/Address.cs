using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSystem.ORM
{
    public class Address
    {

        public int Id;
        public string City;
        public string Street;

        public Address(string city, string street)
        {
            this.City = city;
            this.Street = street;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using AuctionSystem.ORM.DAO.Sqls;

namespace AuctionSystem.ORM
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
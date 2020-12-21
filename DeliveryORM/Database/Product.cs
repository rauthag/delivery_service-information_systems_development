using System;
using System.Collections.Generic;
using System.Text;
using AuctionSystem.ORM.DAO.Sqls;

namespace AuctionSystem.ORM
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public double Weight;

        public Product() {}

        public Product(int id, string name, double price, double weight)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

    }
}
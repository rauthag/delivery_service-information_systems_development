using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DataTransferObjects
{
    public class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public double Weight;

        public Product() { }

        public Product(int id, string name, double price, double weight)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }

    }
}

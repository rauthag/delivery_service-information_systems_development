using System;
using System.Collections.Generic;
using System.Text;
using AuctionSystem.ORM.DAO.Sqls;

namespace AuctionSystem.ORM
{
    public class Storage
    {
        public int Id;
        public string Name;

        public Storage() { }

        public Storage(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

    }
}
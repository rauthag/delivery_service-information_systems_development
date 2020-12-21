using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DataTransferObjects
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

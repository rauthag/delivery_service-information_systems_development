using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataTransferObject.DataTransferObjects;

namespace DataLayer.DataAccessObject.Gateways
{
    public class AddressGateway
    {

        public static String SQL_INSERT = "INSERT INTO Address VALUES(@city, @street)";
        public static String SQL_SELECT = "SELECT addressid, city, street FROM Address";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(addressid) FROM Address";


        public static int Insert(Address Address, Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, Address);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<Address> Select(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Address> Addresses = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Addresses;
        }

        public static int SelectMaxId(Database pDb = null)
        {
            Database db;
            if (pDb == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_MAX_ID);
            SqlDataReader reader = db.Select(command);

            int maxId = 0;
            while (reader.Read())
            {
                int i = -1;
                maxId = reader.GetInt32(++i);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return maxId;
        }



        private static Collection<Address> Read(SqlDataReader reader)
        {
            Collection<Address> Addresses = new Collection<Address>();

            while (reader.Read())
            {
                int i = -1;
                Address address = new Address();
                address.Id = reader.GetInt32(++i);
                address.City = reader.GetString(++i);
                address.Street = reader.GetString(++i);

                Addresses.Add(address);
            }
            return Addresses;
        }


        private static void PrepareCommand(SqlCommand command, Address Address)
        {
            command.Parameters.AddWithValue("@id", Address.Id);
            command.Parameters.AddWithValue("@city", Address.City);
            command.Parameters.AddWithValue("@street", Address.Street);
        }



    }
}


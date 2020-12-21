using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace AuctionSystem.ORM.DAO.Sqls
{
    public class AddressTable
    {

        public static String SQL_INSERT = "INSERT INTO Address VALUES(@city, @street)";
        public static String SQL_SELECT_ID = "INSERT INTO Address VALUES(@city, @street)";


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

        
        private static void PrepareCommand(SqlCommand command, Address Address)
        {
            command.Parameters.AddWithValue("@city", Address.City == null ? DBNull.Value : (object)Address.City);
            command.Parameters.AddWithValue("@street", Address.Street == null ? DBNull.Value : (object)Address.Street);
        }



    }


    
}
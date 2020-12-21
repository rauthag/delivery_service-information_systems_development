using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace AuctionSystem.ORM.DAO.Sqls
{
    public class PersonTable
    {

        public static String SQL_INSERT = "INSERT INTO Person VALUES"
                                        + "(@firstname, @lastname, @birthday, @phonenumber, @email, @gender, @address)";


        public static int Insert(Person Person, Database pDb = null)
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
            PrepareCommand(command, Person);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        
        private static void PrepareCommand(SqlCommand command, Person Person)
        {
            command.Parameters.AddWithValue("@firstname", Person.FirstName);
            command.Parameters.AddWithValue("@lastname", Person.LastName);
            command.Parameters.AddWithValue("@birthday", Person.BirthDay == null ? DBNull.Value : (object)Person.BirthDay);
            command.Parameters.AddWithValue("@phonenumber", Person.PhoneNumber);
            command.Parameters.AddWithValue("@email", Person.Email);
            command.Parameters.AddWithValue("@gender", Person.Gender == null ? DBNull.Value : (object)Person.Gender);
            command.Parameters.AddWithValue("@address", Person.AddressId);

        }



    }


    
}
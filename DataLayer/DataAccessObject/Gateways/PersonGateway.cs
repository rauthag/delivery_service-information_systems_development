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
    public class PersonGateway
    {

        public static String SQL_INSERT = "INSERT INTO Person VALUES"
                                        + "(@firstname, @lastname, CAST(@birthday AS date), @phonenumber, @email, @gender, @address)";
        public static String SQL_SELECT = "SELECT personid, firstname, lastname, birthday, phonenumber, email, gender, addressid FROM Person";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(personid) FROM Person";
        public static String SQL_UPDATE = "UPDATE Person SET firstname=@firstname, lastname=@lastname, birthday=@birthday, phonenumber=@phonenumber,"
                                          + "email=@email, gender=@gender, addressid=@address WHERE personid=@personid";
        public static String SQL_DELETE_ID = "DELETE FROM person WHERE personid=@personid";

        public static String SQL_SELECT_ID = "SELECT personid, firstname, lastname, phonenumber, a.city, a.street " +
                                            "FROM Person JOIN address a on a.addressid = Person.addressid " +
                                            "WHERE personid = @personid";

        public static Person SelectPersonDetails(int id, Database pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);
            command.Parameters.AddWithValue("@personid", id);
            SqlDataReader reader = db.Select(command);

            Person Person = new Person();
            Address Address = new Address();
            Person.Address = Address;

            while (reader.Read())
            {
                int i = -1;
                Person.Id = reader.GetInt32(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                Person.PhoneNumber = reader.GetString(++i);
                Address.City = reader.GetString(++i);
                Address.Street = reader.GetString(++i);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Person;
        }

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

        public static Collection<Person> Select(Database pDb = null)
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

            Collection<Person> persons = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return persons;
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

        private static Collection<Person> Read(SqlDataReader reader)
        {
            Collection<Person> Persons = new Collection<Person>();

            while (reader.Read())
            {
                int i = -1;
                Person person = new Person();
                person.Id = reader.GetInt32(++i);
                person.FirstName = reader.GetString(++i);
                person.LastName = reader.GetString(++i);
                person.BirthDay = Convert.ToString(reader.GetDateTime(++i).Date);
                person.PhoneNumber = reader.GetString(++i);
                person.Gender = reader.GetString(++i);
                person.Address = new Address();
                person.Address.Id = person.AddressId;

                Persons.Add(person);
            }
            return Persons;
        }


        public static int Update(Person Person)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            //PrepareCommand(command, Person);
            command.Parameters.AddWithValue("@personid", Person.Id);
            command.Parameters.AddWithValue("@firstname", Person.FirstName);
            command.Parameters.AddWithValue("@lastname", Person.LastName);
            command.Parameters.AddWithValue("@birthday", Person.BirthDay);
            command.Parameters.AddWithValue("@phonenumber", Person.PhoneNumber);
            command.Parameters.AddWithValue("@email", Person.Email);
            command.Parameters.AddWithValue("@gender", Person.Gender == null ? DBNull.Value : (object)Person.Gender);
            command.Parameters.AddWithValue("@address", Person.AddressId);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static int Delete(int personId)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);
            //PrepareCommand(command, Person);
            command.Parameters.AddWithValue("@personid", personId);

            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }



        private static void PrepareCommand(SqlCommand command, Person Person)
        {
            command.Parameters.AddWithValue("@firstname", Person.FirstName);
            command.Parameters.AddWithValue("@lastname", Person.LastName);
            command.Parameters.AddWithValue("@birthday", Person.BirthDay);
            command.Parameters.AddWithValue("@phonenumber", Person.PhoneNumber);
            command.Parameters.AddWithValue("@email", Person.Email);
            command.Parameters.AddWithValue("@gender", Person.Gender == null ? DBNull.Value : (object)Person.Gender);
            command.Parameters.AddWithValue("@address", Person.AddressId);

        }



    }
}

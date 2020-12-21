using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.ObjectModel;
using DataTransferObject.DataTransferObjects;


namespace DataLayer.DataAccessObject
{
    public class UserGateway
    {

        public static String SQL_INSERT = "INSERT INTO \"User\" VALUES" +
                                          "(@login, @type, @person)";

        public static String SQL_SELECT = "SELECT userid, login, type, personid FROM \"User\"";

        public static String SQL_SELECT_BY_SHIPMENT = "SELECT userid, login, type, personid FROM \"User\"";

        public static String SQL_SELECT_ALL = "SELECT u.userid, p.firstname, p.lastname, p.birthday, p.phonenumber, p.email, " +
                                             "p.gender, u.login, u.type, a.city, a.street" +
                                             " FROM \"User\" u JOIN person p ON u.personid = p.personid " +
                                             "JOIN address a ON p.addressid = a.addressid ";

        public static String SQL_SELECT_CUSTOMERS = "SELECT u.userid, p.personid, p.firstname, p.lastname, p.birthday, p.phonenumber, p.email, " +
                                             "p.gender, u.login, u.type, a.city, a.street" +
                                             " FROM \"User\" u JOIN person p ON u.personid = p.personid " +
                                             "JOIN address a ON p.addressid = a.addressid WHERE u.type = 'customer' ";

        public static String SQL_SELECT_COURS = "SELECT u.userid, p.firstname, p.lastname, p.birthday, p.phonenumber, p.email, " +
                                             "p.gender, u.login, u.type, a.city, a.street" +
                                             " FROM \"User\" u JOIN person p ON u.personid = p.personid " +
                                             "JOIN address a ON p.addressid = a.addressid WHERE u.type = 'courier' ";

        public static String SQL_SELECT_MAX_ID = "SELECT MAX(userid) FROM \"User\"";

        public static String SQL_SELECT_ID = "SELECT u.userid, u.login, u.type, p.firstname, p.lastname, p.birthday, p.phonenumber, p.email," +
                                             "p.gender, a.city, a.street" +
                                             " FROM \"User\" u JOIN person p ON u.personid = p.personid " +
                                             "JOIN address a ON p.addressid = a.addressid " +
                                             "WHERE userid = @userid";


        //public static String SQL_SELECT_ID = "SELECT login, type FROM \"User\" WHERE userid = @userid";

        public static String SQL_UPDATE = "UPDATE \"User\" SET type=@type WHERE userid=@userid";

        public static String SQL_DELETE_ID = "DELETE FROM \"User\" WHERE userid=@userid";



        public static int Insert(User User, Database pDb = null)
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
            PrepareCommand(command, User);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static List<User> SelectCouriers(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_COURS);

            List<User> Users = new List<User>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                User tmpUser = new User();
                Person Person = new Person();
                Address Address = new Address();
                Person.Address = Address;
                tmpUser.Person = Person;

                tmpUser.Id = reader.GetInt32(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                Person.BirthDay = Convert.ToString(reader.GetDateTime(++i).Date);
                Person.PhoneNumber = reader.GetString(++i);
                Person.Email = reader.GetString(++i);
                Person.Gender = reader.GetString(++i);
                tmpUser.Login = reader.GetString(++i);
                tmpUser.Type = reader.GetString(++i);
                Address.City = reader.GetString(++i);
                Address.Street = reader.GetString(++i);
                Users.Add(tmpUser);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Users;
        }




        public static Collection<User> Select(Database pDb = null)
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

            Collection<User> users = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return users;
        }

        public static int Update(User User)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            command.Parameters.AddWithValue("@userid", User.Id);
            command.Parameters.AddWithValue("@type", User.Type);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static User SelectUser(int userId, Database pDb = null)
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
            command.Parameters.AddWithValue("@userid", userId);
            SqlDataReader reader = db.Select(command);

            User User = new User();
            Person Person = new Person();
            Address Address = new Address();
            Person.Address = Address;
            User.Person = Person;

            while (reader.Read())
            {
                int i = -1;
                User.Id = reader.GetInt32(++i);
                User.Login = reader.GetString(++i);
                User.Type = reader.GetString(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                Person.BirthDay = Convert.ToString(reader.GetDateTime(++i).Date);
                Person.PhoneNumber = reader.GetString(++i);
                Person.Email = reader.GetString(++i);
                Person.Gender = reader.GetString(++i);
                Address.City = reader.GetString(++i);
                Address.Street = reader.GetString(++i);


            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return User;
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

        public static int Delete(int userId)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);
            command.Parameters.AddWithValue("@userid", userId);

            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        private static Collection<User> Read(SqlDataReader reader)
        {
            Collection<User> Users = new Collection<User>();

            while (reader.Read())
            {
                int i = -1;
                User user = new User();
                user.Id = reader.GetInt32(++i);
                user.Login = reader.GetString(++i);
                user.Type = reader.GetString(++i);
                user.Person = new Person();
                user.PersonId = user.PersonId;

                Users.Add(user);
            }
            return Users;
        }

        public static List<User> SelectUsers(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ALL);

            List<User> Users = new List<User>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                User tmpUser = new User();
                Person Person = new Person();
                Address Address = new Address();
                Person.Address = Address;
                tmpUser.Person = Person;

                tmpUser.Id = reader.GetInt32(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                Person.BirthDay = Convert.ToString(reader.GetDateTime(++i).Date);
                Person.PhoneNumber = reader.GetString(++i);
                Person.Email = reader.GetString(++i);
                Person.Gender = reader.GetString(++i);
                tmpUser.Login = reader.GetString(++i);
                tmpUser.Type = reader.GetString(++i);
                Address.City = reader.GetString(++i);
                Address.Street = reader.GetString(++i);
                Users.Add(tmpUser);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Users;
        }


        public static List<User> SelectCustomers(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_CUSTOMERS);

            List<User> Users = new List<User>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                User tmpUser = new User();
                Person Person = new Person();
                Address Address = new Address();
                Person.Address = Address;
                tmpUser.Person = Person;

                tmpUser.Id = reader.GetInt32(++i);
                Person.Id = reader.GetInt32(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                Person.BirthDay = Convert.ToString(reader.GetDateTime(++i).Date);
                Person.PhoneNumber = reader.GetString(++i);
                Person.Email = reader.GetString(++i);
                Person.Gender = reader.GetString(++i);
                tmpUser.Login = reader.GetString(++i);
                tmpUser.Type = reader.GetString(++i);
                Address.City = reader.GetString(++i);
                Address.Street = reader.GetString(++i);
                Users.Add(tmpUser);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Users;
        }



        private static void PrepareCommand(SqlCommand command, User User)
        {
            command.Parameters.AddWithValue("@userid", User.Id);
            command.Parameters.AddWithValue("@login", User.Login);
            command.Parameters.AddWithValue("@type", User.Type);
            command.Parameters.AddWithValue("@person", User.PersonId);

        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing;
using DataTransferObject.DataTransferObjects;


namespace DataLayer.DataAccessObject.Gateways
{
    public class ShipmentGateway
    {

        public static String SQL_SELECT_DONE = "SELECT s.shipmentid, sh.dateAndTime FROM shipment s JOIN shipmentmovement sm ON s.shipmentid = sm.shipmentid " +
                                               "JOIN shipmenthistory sh ON sm.shipmentid = sh.shipmentid " +
                                               "WHERE sh.state = @state " +
                                               "ORDER BY DATEDIFF(day, CAST(sh.dateAndTime AS date), GETDATE()) ASC";

        public static String SQL_SELECT_ALL = "SELECT s.shipmentid FROM shipment s";

        public static String SQL_SELECT_CUSTOMER_SHIPMENT = "SELECT s.shipmentid, s.price, s.deliveryprice, sm.\"state\" FROM shipment s LEFT JOIN " +
                                                "shipmentmovement sm on s.shipmentid = sm.shipmentid JOIN person p on p.personid = s.customerid " +
                                                "where s.customerid = @customerid";

        public static String SQL_SELECT_LATE = "SELECT s.shipmentid, DATEDIFF(day, CAST(s.deliveryTime AS date), CAST(sh.dateAndTime AS date)) AS Oneskorenie, " +
                                                "s.deliveryTime, sh.dateAndTime " +
                                                "FROM shipment s JOIN shipmentmovement sm ON s.shipmentid = sm.shipmentid " +
                                                "JOIN shipmenthistory sh ON sm.shipmentid = sh.shipmentid " +
                                                "WHERE sm.courierid = @courierid AND sh.\"state\" = 'caka na vyzdvihnutie' " +
                                                "AND DATEDIFF(day, CAST(s.deliveryTime AS date), CAST(sh.dateAndTime AS date)) > 0 " +
                                                "ORDER BY  DATEDIFF(day, CAST(s.deliveryTime AS date), GETDATE()) ASC";

        public static String SQL_SELECT_NOTDONE = "SELECT s.shipmentid, s.deliveryTime, p.firstname, p.lastname FROM shipment s " +
                                                  "JOIN shipmentmovement sm ON s.shipmentid = sm.shipmentid " +
                                                  "JOIN shipmenthistory sh ON sm.shipmentid = sh.shipmentid " +
                                                  "JOIN person p ON p.personid = s.customerid " +
                                                  "WHERE sm.courierid = @courierid " +
                                                  "AND sm.\"state\" = 'na ceste' AND sh.\"state\" = 'na ceste' " +
                                                  "ORDER BY DATEDIFF(day, CAST(s.deliveryTime AS date), GETDATE()) ASC";

        public static String SQL_SELECT_BYSTATE = "SELECT u.userid AS Kurier, p.firstname, p.lastname, (SELECT COUNT(*) FROM shipmenthistory sh " +
                                                  "JOIN shipmentmovement sm ON sh.shipmentid = sm.shipmentid " +
                                                  "AND sm.courierid = u.userid WHERE sh.\"state\" = 'vyzdvihnuta' ) AS Vyzdvihnute, " +
                                                  "( SELECT COUNT(*) FROM shipmenthistory sh JOIN shipmentmovement sm ON sh.shipmentid = sm.shipmentid " +
                                                  "AND sm.courierid = u.userid WHERE sh.\"state\" = 'nevyzdvihnuta') AS Nevyzdvihnute, " +
                                                  "( SELECT COUNT(*) FROM shipmenthistory sh JOIN shipmentmovement sm ON sh.shipmentid = sm.shipmentid " +
                                                  "AND sm.courierid = u.userid WHERE sh.\"state\" = 'zrusena zakaznikom') AS Zrusene, " +
                                                  "(SELECT COUNT(*) FROM shipmentmovement sm WHERE sm.\"state\" = 'na ceste' AND sm.courierid = u.userid) AS naCeste " +
                                                  "FROM \"user\" u JOIN person p on u.personid = p.personid WHERE u.\"type\"='courier'";

        public static String SQL_SELECT_LATE_CURR = "SELECT s.shipmentid, DATEDIFF(day, CAST(s.deliveryTime AS date),  GETDATE()) AS delay, s.deliverytime FROM shipment s JOIN shipmentmovement sm ON s.shipmentid = sm.shipmentid " +
                                                  "JOIN shipmenthistory sh ON sm.shipmentid = sh.shipmentid WHERE sm.courierid = @courierID " +
                                                  "AND sh.\"state\" = 'na ceste' AND DATEDIFF(day, CAST(s.deliveryTime AS date),  GETDATE()) > 0 " +
                                                  "ORDER BY DATEDIFF(day, CAST(s.deliveryTime AS date), GETDATE()) ASC";

        public static String SQL_SELECT_DETAIL = "SELECT s.shipmentid, s.customerid, s.\"type\", s.price, s.deliveryprice, s.\"weight\", s.ordertime, s.deliveryTime " +
                                                 "FROM shipment s " +
                                                  "WHERE s.shipmentid = @shipmentid";



        public static String SQL_SELECT_HISTORY = "SELECT sh.dateAndTime, sh.state FROM shipment s JOIN shipmentmovement sm ON s.shipmentid = sm.shipmentid " +
                                               "JOIN shipmenthistory sh ON sm.shipmentid = sh.shipmentid " +
                                               "WHERE s.shipmentid = @shipmentid";

        public static String SQL_SELECT_SELLERS = "select s.storageid, s.\"name\" from storage s where s.type = 'predajca'";

        public static String SQL_SELECT_PRODUCTS = "select p.productid, p.productname, p.productprice, p.productweight from product p";



        public static List<Product> SelectProducts(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_PRODUCTS);

            List<Product> Products = new List<Product>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Product p = new Product();
                p.Id = reader.GetInt32(++i);
                p.Name = Convert.ToString(reader["productname"]);
                p.Price = Convert.ToDouble(reader["productprice"]);
                p.Weight = Convert.ToDouble(reader["productweight"]);
                Products.Add(p);

            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Products;
        }

        public static List<Storage> SelectSellers(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_SELLERS);

            List<Storage> Storages = new List<Storage>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Storage st = new Storage();
                st.Id = reader.GetInt32(++i);
                st.Name = reader.GetString(++i);
                Storages.Add(st);

            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Storages;
        }

        public static List<Shipment> SelectShipmentHistory(int shipmentid, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_HISTORY);
            command.Parameters.AddWithValue("@shipmentid", shipmentid);

            List<Shipment> ShipmentHistory = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();
                tmpShipment.DeliveryTime = Convert.ToString(reader.GetDateTime(++i).Date);
                tmpShipment.Type = reader.GetString(++i);

                ShipmentHistory.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return ShipmentHistory;
        }

        public static List<Shipment> SelectCustomerShipments(int customerid, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_CUSTOMER_SHIPMENT);
            command.Parameters.AddWithValue("@customerid", customerid);

            List<Shipment> Shipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);


            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();
                tmpShipment.Id = reader.GetInt32(++i);
                tmpShipment.Price = Convert.ToDouble(reader["price"]);
                tmpShipment.DeliveryPrice = Convert.ToDouble(reader["deliveryprice"]);
                tmpShipment.State = Convert.ToString(reader["state"]);

                Shipments.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Shipments;
        }

        public static List<Shipment> SelectShipmentDetail(int shipmentid, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_DETAIL);
            command.Parameters.AddWithValue("@shipmentid", shipmentid);

            List<Shipment> ShipmentDetails = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();
                Person Person = new Person();
                tmpShipment.Person = Person;
                Address Address = new Address();
                Person.Address = Address;

                tmpShipment.Id = reader.GetInt32(++i);
                Person.Id = reader.GetInt32(++i);
                tmpShipment.Type = reader.GetString(++i);
                tmpShipment.Price = Convert.ToDouble(reader["price"]);
                tmpShipment.DeliveryPrice = Convert.ToDouble(reader["deliveryPrice"]);
                tmpShipment.Weight = Convert.ToDouble(reader["weight"]);
                tmpShipment.OrderTime = Convert.ToString(reader["ordertime"]);
                tmpShipment.DeliveryTime = Convert.ToString(reader["deliveryTime"]);

                ShipmentDetails.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return ShipmentDetails;
        }



        public static List<Shipment> SelectLateShipmentsByCourierId(int courierId, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LATE);
            command.Parameters.AddWithValue("@courierid", courierId);

            List<Shipment> LateShipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();

                tmpShipment.Id = reader.GetInt32(++i);
                tmpShipment.Delay = reader.GetInt32(++i);
                tmpShipment.DeliveryTime = Convert.ToString(reader.GetDateTime(++i).Date);
                tmpShipment.Delivered = Convert.ToString(reader.GetDateTime(++i).Date);
                LateShipments.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return LateShipments;
        }

        public static List<Shipment> SelectAllShipments(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ALL);

            List<Shipment> AllShipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();
                tmpShipment.Id = reader.GetInt32(++i);
                AllShipments.Add(tmpShipment);

            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return AllShipments;
        }

        public static List<Shipment> SelectCurrLateShipmentsByCourierId(int courierId, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_LATE_CURR);
            command.Parameters.AddWithValue("@courierid", courierId);

            List<Shipment> LateShipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();

                tmpShipment.Id = reader.GetInt32(++i);
                tmpShipment.Delay = reader.GetInt32(++i);
                tmpShipment.DeliveryTime = Convert.ToString(reader.GetDateTime(++i).Date);
                LateShipments.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return LateShipments;
        }

        public static List<Shipment> SelectDoneShipmentsByState(string state, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_DONE);
            command.Parameters.AddWithValue("@state", state);

            List<Shipment> LateShipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();

                tmpShipment.Id = reader.GetInt32(++i);
                tmpShipment.DoneAt = Convert.ToString(reader.GetDateTime(++i).Date);
                LateShipments.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return LateShipments;
        }

        public static List<Shipment> SelectNotDoneShipmentsByCourierId(int courierId, Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_NOTDONE);
            command.Parameters.AddWithValue("@courierid", courierId);

            List<Shipment> LateShipments = new List<Shipment>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                Shipment tmpShipment = new Shipment();
                Person Person = new Person();
                tmpShipment.Person = Person;

                tmpShipment.Id = reader.GetInt32(++i);
                tmpShipment.DeliveryTime = Convert.ToString(reader.GetDateTime(++i).Date);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                LateShipments.Add(tmpShipment);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return LateShipments;
        }

        public static List<User> SelectShipmentsByState(Database pDb = null)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_BYSTATE);

            List<User> Couriers = new List<User>();
            SqlDataReader reader = db.Select(command);

            while (reader.Read())
            {
                int i = -1;
                User tmpUser = new User();
                Person Person = new Person();
                tmpUser.Person = Person;

                tmpUser.Id = reader.GetInt32(++i);
                Person.FirstName = reader.GetString(++i);
                Person.LastName = reader.GetString(++i);
                tmpUser.CourPicked = reader.GetInt32(++i);
                tmpUser.CourNotPicked = reader.GetInt32(++i);
                tmpUser.CourCanceled = reader.GetInt32(++i);
                tmpUser.CourOnWay = reader.GetInt32(++i);

                Couriers.Add(tmpUser);
            }

            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return Couriers;
        }


        public static string CreateAndUpdateShipment(string type, int customerID, int sellerStorageID, int receiveStorageID,
                                                     double pricePerG, string productIds, Database pDb)
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

            // 1.  create a command object identifying the stored procedure
            SqlCommand command = db.CreateCommand("CreateAndUpdateShipment");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // type of shipment - input
            SqlParameter iType = new SqlParameter();
            iType.ParameterName = "@type";
            iType.DbType = DbType.String;
            iType.Value = type;
            iType.Direction = ParameterDirection.Input;
            command.Parameters.Add(iType);

            // id of customer - input
            SqlParameter iCustomerId = new SqlParameter();
            iCustomerId.ParameterName = "@customerID";
            iCustomerId.DbType = DbType.Int32;
            iCustomerId.Value = customerID;
            iCustomerId.Direction = ParameterDirection.Input;
            command.Parameters.Add(iCustomerId);

            // id of seller - input
            SqlParameter iSellerId = new SqlParameter();
            iSellerId.ParameterName = "@sellerStorageID";
            iSellerId.DbType = DbType.Int32;
            iSellerId.Value = sellerStorageID;
            iSellerId.Direction = ParameterDirection.Input;
            command.Parameters.Add(iSellerId);


            // id of receive storage - input
            SqlParameter iReceiveId = new SqlParameter();
            iReceiveId.ParameterName = "@receiveStorageID";
            iReceiveId.DbType = DbType.Int32;
            iReceiveId.Value = receiveStorageID;
            iReceiveId.Direction = ParameterDirection.Input;
            command.Parameters.Add(iReceiveId);

            // price per gram of weight - input
            SqlParameter iPricePerG = new SqlParameter();
            iPricePerG.ParameterName = "pricePerG";
            iPricePerG.DbType = DbType.Double;
            iPricePerG.Value = pricePerG;
            iPricePerG.Direction = ParameterDirection.Input;
            command.Parameters.Add(iPricePerG);

            SqlParameter iProducts = new SqlParameter();
            iProducts.ParameterName = "@productIds";
            iProducts.DbType = DbType.String;
            iProducts.Value = productIds;
            iProducts.Direction = ParameterDirection.Input;
            command.Parameters.Add(iProducts);


            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);

            // 5. get values of the output parameters
            //string result = command.Parameters["@result"].Value.ToString();
            string result = "Shipment has been created.";

            if (pDb == null)
            {
                db.Close();
            }
            return result;
        }

        public static string LateShipNotificationAndUpdate(string NotificationText, Database pDb)
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

            // 1.  create a command object identifying the stored procedure
            SqlCommand command = db.CreateCommand("LateShipNotificationAndUpdate");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // notificationText - input
            SqlParameter iText = new SqlParameter();
            iText.ParameterName = "@text";
            iText.DbType = DbType.String;
            iText.Value = NotificationText;
            iText.Direction = ParameterDirection.Input;
            command.Parameters.Add(iText);


            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);
            string result = "Delivery prices has been updated and notifications sent";

            if (pDb == null)
            {
                db.Close();
            }
            return result;
        }

        public static string HistoryAndMovement(int shipmentID, string state, int courierID, Database pDb)
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

            // 1.  create a command object identifying the stored procedure
            SqlCommand command = db.CreateCommand("HistoryAndMovement");

            // 2. set the command object so it knows to execute a stored procedure
            command.CommandType = CommandType.StoredProcedure;

            // id of shipment - input
            SqlParameter iShipmentID = new SqlParameter();
            iShipmentID.ParameterName = "@shipmentID";
            iShipmentID.DbType = DbType.Int32;
            iShipmentID.Value = shipmentID;
            iShipmentID.Direction = ParameterDirection.Input;
            command.Parameters.Add(iShipmentID);

            // state - input
            SqlParameter iState = new SqlParameter();
            iState.ParameterName = "@state";
            iState.DbType = DbType.String;
            iState.Value = state;
            iState.Direction = ParameterDirection.Input;
            command.Parameters.Add(iState);

            // id of customer - input
            SqlParameter iCourierID = new SqlParameter();
            iCourierID.ParameterName = "@courierID";
            iCourierID.DbType = DbType.Int32;
            iCourierID.Value = courierID;
            iCourierID.Direction = ParameterDirection.Input;
            command.Parameters.Add(iCourierID);

            // 4. execute procedure
            int ret = db.ExecuteNonQuery(command);

            // 5. get values of the output parameters
            //string result = command.Parameters["@result"].Value.ToString();
            string result = "Shipment " + shipmentID + " " + "has been updated";

            if (pDb == null)
            {
                db.Close();
            }
            return result;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using AuctionSystem.ORM;
using AuctionSystem.ORM.DAO.Sqls;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace AuctionSystem
{
    public class dbProcesor
    {
        private static Database db;

        public static int InsertUser(string firstname, string lastname, string birthday,
                                    string phonenumber, string email, string gender, string city,
                                    string street, string login, string type)
        {
            db = new Database();
            db.Connect();

            Address a = new Address(city, street);
            AddressTable.Insert(a);
            a.Id = AddressTable.SelectMaxId(db);

            Person p = new Person(firstname, lastname, birthday, phonenumber, email, gender, a, a.Id);
            PersonTable.Insert(p);
            p.Id = PersonTable.SelectMaxId(db);

            User u = new User(login, type, p, p.Id);
            u.Id = UserTable.SelectMaxId(db);

            int uAdded = UserTable.Insert(u, db);
            db.Close();

            return uAdded;
        }

       public static List<User> GetUserList(Database pDb = null)
        {
            db = new Database();
            db.Connect();
            List<User> Users = UserTable.SelectUsers(db);
            db.Close();
            return Users;
        }

        public static int UpdateUser(int id, string type)
        {
            db = new Database();
            db.Connect();

            User user = new User();
            user.Id = id;
            user.Type = type;
            int updated = UserTable.Update(user);

            db.Close();
            return updated;
        }

        public static int DeleteUser(int id)
        {
            db = new Database();
            db.Connect();

            int updated = UserTable.Delete(id);

            db.Close();
            return updated;
        }

        public static List<Shipment> SelectAllShipments()
        {
            db = new Database();
            db.Connect();

            List<Shipment> AllShipments = ShipmentTable.SelectAllShipments(db);

            db.Close();
            return AllShipments;

        }

        public static List<Shipment> ShipmentDetails(int id)
        {
            db = new Database();
            db.Connect();

            List<Shipment> ShipmentDetails = ShipmentTable.SelectShipmentDetail(id, db);

            db.Close();
            return ShipmentDetails;

        }

        public static Person PersonDetails(int id)
        {
            db = new Database();
            db.Connect();

            Person PersonDetails = PersonTable.SelectPersonDetails(id, db);

            db.Close();
            return PersonDetails;

        }

        public static List<Shipment> ShipmentHistory(int shipmentid)
        {
            db = new Database();
            db.Connect();

            List<Shipment> ShipmentHistory = ShipmentTable.SelectShipmentHistory(shipmentid, db);

            db.Close();
            return ShipmentHistory;
        }

        public static List<Shipment> DoneShipments(string state)
        {
            db = new Database();
            db.Connect();

            List<Shipment> Shipments = ShipmentTable.SelectDoneShipmentsByState(state);

            db.Close();
            return Shipments;
        }

        public static List<User> ShipmentsByState()
        {
            db = new Database();
            db.Connect();

            List<User> Shipments = ShipmentTable.SelectShipmentsByState(db);

            db.Close();
            return Shipments;
        }


        public static List<User> Customers()
        {
            db = new Database();
            db.Connect();

            List<User> Users = UserTable.SelectCustomers(db);

            db.Close();
            return Users;
        }


        public static List<User> Couriers()
        {
            db = new Database();
            db.Connect();

            List<User> couriers = UserTable.SelectCouriers(db);

            db.Close();
            return couriers;
        }

        public static List<Shipment> LateShipmentsByCourierId(int courierId)
        {
            db = new Database();
            db.Connect();

            List<Shipment> Shipments = ShipmentTable.SelectLateShipmentsByCourierId(courierId);

            db.Close();
            return Shipments;
        }

        public static List<Shipment> CustomerShipments(int customerid)
        {
            db = new Database();
            db.Connect();

            List<Shipment> Shipments = ShipmentTable.SelectCustomerShipments(customerid);

            db.Close();
            return Shipments;
        }

        public static List<Storage> Sellers()
        {
            db = new Database();
            db.Connect();

            List<Storage> storages = ShipmentTable.SelectSellers(db);

            db.Close();
            return storages;
        }

        public static List<Product> Products()
        {
            db = new Database();
            db.Connect();

            List<Product> Products = ShipmentTable.SelectProducts(db);

            db.Close();
            return Products;
        }

        public static string CreateAndUpdateShipment(string type, int customerID, int sellerStorageID, int receiveStorageID,
                                                     double pricePerG, string productIds)
        {
            db = new Database();
            db.Connect();

            string shipment = ShipmentTable.CreateAndUpdateShipment(type, customerID, sellerStorageID, receiveStorageID,
                              pricePerG, productIds, db);

            db.Close();
            return shipment;
        }

        public static string HistoryAndMovement(int shipmentID, string state, int courierID)
        {
            db = new Database();
            db.Connect();

            string history = ShipmentTable.HistoryAndMovement(shipmentID, state, courierID, db);

            db.Close();
            return history;

        }

        
        public static List<Shipment> SelectCurrLateShipmentsByCourierId(int courierId)
        {
            db = new Database();
            db.Connect();

            List<Shipment> lateShipments = ShipmentTable.SelectCurrLateShipmentsByCourierId(courierId, db);

            db.Close();

            return lateShipments;
        }


        public static List<Shipment> SelectNotDoneShipmentsByCourierId(int courierId)
        {
            db = new Database();
            db.Connect();

            List<Shipment> notDoneShipments = ShipmentTable.SelectNotDoneShipmentsByCourierId(courierId, db);

            db.Close();

            return notDoneShipments;
        }

    }
}

using System;
using System.Text;
using AuctionSystem.ORM;
using System.Collections.ObjectModel;
using AuctionSystem.ORM.DAO.Sqls;
using System.Collections.Generic;

namespace AuctionSystem
{

    class Program
    {
        static void Main(string[] args)
        {

            Database db = new Database();
            db.Connect();


            /***1.1 Vloženie užívateľa***/
            Address a1 = new Address("Bratislava", "Lomnická 9");
            AddressTable.Insert(a1);
            a1.Id = AddressTable.SelectMaxId(db);
    
            Person p1 = new Person("Lukáš", "Náhodný", "1996-10-12", "+421" + RandomString("number", 9),
                                   RandomString("word", 5) + "@email.com","muz", a1, a1.Id);
            PersonTable.Insert(p1);
            p1.Id = PersonTable.SelectMaxId(db);

 
            User u1 = new User((p1.LastName.Substring(0, 3) + RandomString("number", 4)).ToLower(),
                               "courier", p1, p1.Id);
            UserTable.Insert(u1);
            u1.Id = UserTable.SelectMaxId(db);

            
            

            /***1.2 Aktualizácia užívateľa***/
            p1.LastName = "Aktualizovaný";
            PersonTable.Update(p1);
            u1.Login = (p1.LastName.Substring(0, 3) + RandomString("number", 4)).ToLower();
            UserTable.Update(u1);


            /***1.3 Zrušenie užívateľa**/
            //int UserToDelete = 15;
            //UserTable.Delete(UserToDelete);
            //PersonTable.Delete(UserToDelete);
            //Console.WriteLine("User with ID " + UserToDelete + " has been deleted." );
            //Console.WriteLine(" ");

            List<Shipment> Shipments2 = ShipmentTable.SelectAllShipments(db);

            foreach(var shipment in Shipments2)
            {
                Console.WriteLine(shipment.Id);
            }

            /*List<Shipment> ShipmentsD = ShipmentTable.SelectShipmentDetail(21,db);

            foreach (var shipment in ShipmentsD)
            {
                Console.WriteLine(shipment.Id.ToString() +  shipment.Type + " " + shipment.Price + " " + shipment.DeliveryPrice + " " +
                    shipment.Weight + " " + shipment.OrderTime + " " + shipment.DeliveryTime);
            }*/


            /**1.4 Zoznam užívateľov**/
            List<User> Users = UserTable.SelectUsers(db);
            Console.WriteLine("(1.4)User list");

            foreach (var user in Users)
            {
                Console.WriteLine("  " + user.Id + "  " + user.Person.FullName + " " + user.Login + "   " +
                                  user.Type + " " + user.Person.Email + " " + user.Person.Address.City + "...");
            }
            Console.WriteLine(" ");


            /***1.5 Detail užívateľa***/
            User UserDetail = UserTable.SelectUser(p1.Id, db);
            Console.WriteLine("(1.5)User detail with ID: " + p1.Id + " " + UserDetail.Person.FullName + " " +
                               UserDetail.Login + " " + UserDetail.Type + " " + UserDetail.Person.Address.City + "....");
            Console.WriteLine(" ");


            /***2.1 Zoznam neskoro doručených zásielok (podľa id kuriéra)***/
            int CourierToCheckId = 3;
            List<Shipment> LateShipments = ShipmentTable.SelectLateShipmentsByCourierId(CourierToCheckId, db);
            Console.WriteLine("(2.1)Late shipments by courier id");

            foreach(var shipment in LateShipments)
            {
                Console.WriteLine(" " + shipment.Id.ToString() + " with " + shipment.Delay.ToString() + " day(s) delay. " + "Delivered " +
                                   shipment.Delivered + " instead of " + shipment.DeliveryTime);
            }
            Console.WriteLine(" ");


            /***2.2 Ukončené zásielky***/
            string StateToCheck = "zrusena zakaznikom"; /*vyzdvihnuta, nevyzdvihnuta*/
;           List<Shipment> DoneShipments = ShipmentTable.SelectDoneShipmentsByState(StateToCheck, db);
            Console.WriteLine("(2.2)Done shipments by state");

            foreach(var shipment in DoneShipments)
            {
                Console.WriteLine(" " + shipment.Id + " done at " + shipment.DoneAt);
            }
            Console.WriteLine(" ");


            /***2.3 Nedoručené zásielky***/
            int IdOfCourierChecking = 5;
            List<Shipment> NotDoneShipments = ShipmentTable.SelectNotDoneShipmentsByCourierId(IdOfCourierChecking, db);
            Console.WriteLine("(2.3)My shipments to deliver");

            foreach (var shipment in NotDoneShipments)
            {
                Console.WriteLine(" " + shipment.Id + " should be delivered at " + shipment.DeliveryTime + 
                                  " to "  + shipment.Person.FullName);
            }
            Console.WriteLine(" ");


            /***2.4 Počet jednotlivých zásielok pre ich stavy (u každého kuriéra)***/
            List<User> ShipmentsByState = ShipmentTable.SelectShipmentsByState(db);
            Console.WriteLine("(2.4)Shipment count by its state with courierID");
            Console.WriteLine(" " + "Courier ID" + "   Picked   Not Picked   Canceled   On way");

            foreach (var user in ShipmentsByState)
            {
                Console.WriteLine("      " + user.Id + "         " + user.CourPicked + "         " + user.CourNotPicked
                                  + "            " + user.CourCanceled + "         " + user.CourOnWay);
            }
            Console.WriteLine(" ");


            /***2.5 Aktuálne meškajúce zásielky (kuriéra)***/
            List<Shipment> CurrLateShipments = ShipmentTable.SelectCurrLateShipmentsByCourierId(7, db);
            Console.WriteLine("(2.5)My currently late shipments");

            foreach(var shipment in CurrLateShipments)
            {
                Console.WriteLine(" " + shipment.Id + " should be delivered " + shipment.Delay + " day(s) ago.");
            }
            Console.WriteLine(" ");

            /***3.3 Vloženie novej zásielky a automatická aktualizácia cien a váhy***/
            Console.WriteLine("(3.3)Adding new shipment...");
            Person p2 = new Person("Neregistrovaný", "Užívateľ", "1996-10-12", "+421" + RandomString("number", 9),
                       RandomString("word", 5) + "@email.com", "muz", a1, a1.Id);
            PersonTable.Insert(p2);
            p2.Id = PersonTable.SelectMaxId(db);

            string productIds = "4,5,6"; /* ID produtkov, ktoré si užívateľ vyberie v rozhraní*/;
            String CreateAndUpdateResult = ShipmentTable.CreateAndUpdateShipment("Test funkcie 3.3.", p2.Id, 1, 4, 2, productIds, db);
            Console.WriteLine(CreateAndUpdateResult);
            Console.WriteLine(" ");

            /***3.4 Automatická aktualizácia ceny doručenia pri oneskorenom doručení a upozornenie zákazníka o tejto udalosti***/
            Console.WriteLine("(3.4)Updating shipment delivery prices and sending notifications...");
            Console.WriteLine(ShipmentTable.LateShipNotificationAndUpdate("Ospravedlňujeme sa za meškanie vašej zásielky.", db));
            Console.WriteLine(" ");

            /***3.5 História a pohyb zásielky***/
            String Updated = ShipmentTable.HistoryAndMovement(11122, "zrusena zakaznikom", 4, db);
            Console.WriteLine("(3.5) " + Updated);

            Console.ReadLine();


            db.Close();
            
        }



        private static string RandomString(string type, int length)
        {
            const string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWZ";
            const string numPool = "0123456789";
            var builder = new StringBuilder();
            Random random_ = new Random();

            if (type == "word")
            {
                for (var i = 0; i < length; i++)
                {
                    var c = pool[random_.Next(0, pool.Length)];
                    builder.Append(c);

                }
            }
            if (type == "number")
            {
                for (var i = 0; i < length; i++)
                {
                    var c = numPool[random_.Next(0, numPool.Length)];
                    builder.Append(c);

                }
            }

            return builder.ToString();
        }


    }
}

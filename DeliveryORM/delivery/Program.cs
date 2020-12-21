using System;
using AuctionSystem.ORM;
using AuctionSystem.ORM.DAO.Sqls;

namespace AuctionSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            db.Connect();

            
            Address a1 = new Address("Žilina","Fatranská 6"); 
            Address a2 = new Address("Martin","Martinská 6");
            //AddressTable.Insert(a1, db);
            //AddressTable.Insert(a2, db);

            Person p1 = new Person(generateString(8), generateString(8), null, "+421" + generateString(9),
                                   generateString(4) + "@email.com", "Muz", a1, a1.Id);
            PersonTable.Insert(p1);

            //Person p1 = new Person("Lukáš","Paučin","1996-06-19", "+)

            /*
            Person p1 = new Person();
            p1.Id = 1;
            p1.FirstName = "Lukáš";
            p1.LastName = "Paučin";
            p1.BirthDay = null;
            p1.PhoneNumber = "+421521645";
            p1.Email = "email@email.com";
            p1.Gender = "Muz";
            p1.Address = a1;
            p1.AddressId = a1.Id;

            PersonTable.Insert(p1, db);
            */

            db.Close();
            
        }

        public static string generateString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}

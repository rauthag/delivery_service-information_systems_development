using System;

namespace AuctionSystem.ORM
{
    public class Person
    {
        public int Id{ get; set; }
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public string BirthDay{ get; set; }
        public string PhoneNumber{ get; set; }
        public string Email{ get; set; }
        public string Gender{ get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }

        //Artificial columns (physically not in the database)
        public String FullName { get { return this.FirstName + " " + this.LastName; } }

        public Person(string firstName, string lastName, string birthDay,
                      string phoneNumber, string email, string gender, Address address, int addressId)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthDay;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
            this.AddressId = addressId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DataTransferObjects
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }

        //Artificial columns (physically not in the database)
        public String FullName { get { return this.FirstName + " " + this.LastName; } }


        public Person() { }

        public Person(string firstname, string lastname, string birthday, string phonenumber,
                      string email, string gender, Address address, int addressid)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.BirthDay = birthday;
            this.PhoneNumber = phonenumber;
            this.Email = email;
            this.Gender = gender;
            this.Address = address;
            this.AddressId = addressid;
        }
    }
}

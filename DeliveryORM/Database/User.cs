using System;

namespace AuctionSystem.ORM
{
    public class User
    {
        public int Id{ get; set; }
        public string Login{ get; set; }
        public string Type{ get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }

        public int? CourPicked { get; set; }
        public int? CourNotPicked { get; set; }
        public int? CourCanceled { get; set; }
        public int? CourOnWay { get; set; }

        public User() { }

        public User(string login, string type, Person person, int personId)
        {
            this.Login = login;
            this.Type = type;
            this.Person = person;
            this.PersonId = personId;
        }

    }

}
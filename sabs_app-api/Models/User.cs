using System;
using System.Collections.Generic;

namespace sabs_app_api.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public IList<IPAdress> IPs { get; set; }
        public User()
        {
            ID = Guid.NewGuid();
        }

        public static User Create(string firstname, string lastname, string email, string password, string phone)
        {
            return new User
            {
                ID = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password,
                Phone = phone,
                Role = "Admin" // just for testing, I should transform Role Class into a enum
            };
        }

    }
}

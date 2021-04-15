using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public IList<IPAdress> IPs { get; set; }

        public User()
        {
            ID = Guid.NewGuid();
        }

        public static User Create(string firstname, string lastname, string email, string password)
        {
            return new User
            {
                ID = Guid.NewGuid(),
                FirstName = firstname,
                LastName = lastname,
                Email = email,
                Password = password
            };
        }

    }
}

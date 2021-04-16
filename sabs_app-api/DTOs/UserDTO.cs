using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.DTOs
{
    public class UserDTO
    {
        public UserDTO(Guid iD, string firstName, string lastName, string email, IList<IPAdress> iPs)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            IPs = iPs;
        }

        public Guid ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }


        public IList<IPAdress> IPs { get; set; }
    }
}

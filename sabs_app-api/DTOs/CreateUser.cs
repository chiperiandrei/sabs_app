using MediatR;
using sabs_app_api.Models;
using System.Collections.Generic;

namespace sabs_app_api.Controllers
{
    public class CreateUser : IRequest<User>
    {


        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
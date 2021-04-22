using MediatR;
using sabs_app_api.Models;

namespace sabs_app_api.DTOs
{
    public class CreateUser : IRequest<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
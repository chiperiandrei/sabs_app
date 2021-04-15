using MediatR;
using sabs_app_api.Controllers;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class CreateUserHandler : IRequestHandler<CreateUser, User>
    {
        private readonly Context _context;
        public CreateUserHandler(Context context)
        {
            _context = context;
        }
        public async Task<User> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User user = User.Create(request.FirstName,
                request.LastName, request.Email, passwordHash);
            if (_context.Users.FirstOrDefault(u => u.Email == user.Email) == default(User))
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user;
            }
            else
                return null;

        }
    }
}
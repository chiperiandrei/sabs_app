using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.Controllers;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class LoginUserHandler : IRequestHandler<LoginUser, UserDTO>
    {
        private readonly Context _context;
        public LoginUserHandler(Context context)
        {
            _context = context;
        }
        public async Task<UserDTO> Handle(LoginUser request, CancellationToken cancellationToken)
        {

     

            var actualUser = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);
            if (actualUser != null)
                if (BCrypt.Net.BCrypt.Verify(request.Password,actualUser.Password))
                {
                    UserDTO loginObj = new UserDTO(actualUser.ID,actualUser.FirstName, actualUser.FirstName, actualUser.Email,actualUser.IPs,actualUser.Phone);
                    return loginObj;
                }
            return null;
        }
    }
}
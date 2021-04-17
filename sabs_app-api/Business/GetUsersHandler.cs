using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.Controllers;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class GetUsersHandler : IRequestHandler<GetUsers, List<UserDTO>>
    {
        private readonly Context _context;
        public GetUsersHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<UserDTO>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Select(p => new UserDTO(p.ID, p.FirstName, p.LastName, p.Email, p.IPs,p.Phone)).ToListAsync();
            return users;
        }

    }
}
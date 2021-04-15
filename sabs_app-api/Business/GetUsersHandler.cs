using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.Controllers;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class GetUsersHandler : IRequestHandler<GetUsers, List<User>>
    {
        private readonly Context _context;
        public GetUsersHandler(Context context)
        {
            _context = context;
        }
        public async Task<List<User>> Handle(GetUsers request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
    }
}
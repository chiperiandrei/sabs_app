using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly Context _context;
        public GetUserByIdHandler(Context context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ID == request.UserId);
            if (user != null)
            {
                return user;
            }
            else
                return null;

        }
    }
}

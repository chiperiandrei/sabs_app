using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser, User>
    {
        private readonly Context _context;
        public DeleteUserHandler(Context context)
        {
            _context = context;
        }
        public async Task<User> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var x = request.UserId;
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ID == request.UserId);
            if (user == null)
            {
                throw new Exception("User does not exists");
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);
            return null;
        }
    }

}

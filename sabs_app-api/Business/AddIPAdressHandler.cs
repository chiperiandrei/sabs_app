using MediatR;
using Microsoft.EntityFrameworkCore;
using sabs_app_api.DTOs;
using sabs_app_api.Infrastructure;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace sabs_app_api.Business
{


    public class AddIPAdressHandler : IRequestHandler<AddIPAdress, User>
    {
        private readonly Context _context;
        public AddIPAdressHandler(Context context)
        {
            _context = context;
        }
        public async Task<User> Handle(AddIPAdress request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.ID == request.UserId);
            var new_ip = IPAdress.Create(user, request.IPAdress);
            _context.IPs.Add(new_ip);
            await _context.SaveChangesAsync();
            return null;

        }
    }
}

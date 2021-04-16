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


    public class AddIPAdressHandler : IRequestHandler<AddIPAdress, IPAdress>
    {
        private readonly Context _context;
        public AddIPAdressHandler(Context context)
        {
            _context = context;
        }
        public async Task<IPAdress> Handle(AddIPAdress request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email== request.Email);
            var new_ip = IPAdress.Create(user, request.IPAdress);
            var uniq_ip_per_user =  _context.IPs.Where(s=>s.UserID==user.ID).Where(s=>s.IPValue==request.IPAdress).ToList();
            if (uniq_ip_per_user.Count==0)
            {
                _context.IPs.Add(new_ip);
                await _context.SaveChangesAsync();
                return new_ip;
            }
           
            return null;

        }
    }
}

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


    public class AddPendingIPAdressHandler : IRequestHandler<AddPendingIPAdress, PendingAdresses>
    {
        private readonly Context _context;
        public AddPendingIPAdressHandler(Context context)
        {
            _context = context;
        }
        public async Task<PendingAdresses> Handle(AddPendingIPAdress request, CancellationToken cancellationToken)
        {
            var new_ip = PendingAdresses.Create(request.Email, request.IPAdress);
            
                _context.PendingAdresses.Add(new_ip);
                await _context.SaveChangesAsync();
                return new_ip;
            
           
            return null;

        }
    }
}

using MediatR;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.DTOs
{
   
    public class DeleteUser : IRequest<User>
    {

        public DeleteUser(Guid id)
        {
            UserId = id;
        }

        public Guid UserId { get; set; }
    }
}

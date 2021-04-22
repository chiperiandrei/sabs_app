using MediatR;
using sabs_app_api.Models;
using System;

namespace sabs_app_api.DTOs
{
    public class DeleteUser : IRequest<User>
    {
        public Guid UserId { get; set; }
        public DeleteUser(Guid id)
        {
            UserId = id;
        }
    }
}

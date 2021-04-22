using MediatR;
using sabs_app_api.Models;
using System;

namespace sabs_app_api.DTOs
{
    public class GetUserById : IRequest<User>
    {
        public Guid UserId { get; }

        public GetUserById(Guid id)
        {
            UserId = id;
        }
    }
}
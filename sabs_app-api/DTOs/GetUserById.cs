﻿using MediatR;
using sabs_app_api.Models;
using System;

namespace sabs_app_api.Controllers
{
    public class GetUserById : IRequest<User>
    {
        public GetUserById(Guid id)
        {
            UserId = id;
        }

        public Guid UserId { get; }
    }
}
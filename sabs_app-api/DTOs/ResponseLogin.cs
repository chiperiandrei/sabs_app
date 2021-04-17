

using MediatR;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.DTOs
{
    public class ResponseLogin : IRequest<ResponseLogin>
    {
        public ResponseLogin(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
using MediatR;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sabs_app_api.DTOs
{
    public class AddPendingIPAdress : IRequest<PendingAdresses>
    {
        public string Email{ get; set; }

        public string IPAdress { get; set; }
    }

}

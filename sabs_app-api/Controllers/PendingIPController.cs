using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sabs_app_api.DTOs;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sabs_app_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PendingIPController : ControllerBase
    {


        private readonly IMediator _mediator;

        public PendingIPController(IMediator mediator)
        {
            _mediator = mediator;
        }


        
        [HttpPost]
        public async Task<ActionResult<AddPendingIPAdress>> AddPendingIp([FromBody] AddPendingIPAdress request)
        {
            var res = await _mediator.Send(request);
            if (res==null)
            {

                return Conflict();
            }

            return Ok();

        }

    }
}

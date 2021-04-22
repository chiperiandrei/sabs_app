using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sabs_app_api.DTOs;
using sabs_app_api.Models;
using System.Threading.Tasks;

namespace sabs_app_api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IPAdressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IPAdressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<IPAdress>> AddIp([FromBody] AddIPAdress request)
        {
            var res = await _mediator.Send(request);
            if (res == null)
            {

                return Conflict();
            }

            return Ok();

        }

    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using sabs_app_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sabs_app_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {


        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _mediator.Send(new GetUsers());
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] CreateUser request)
        {
            var user = await _mediator.Send(request);
            return user;
        }



        [HttpPost]
        public async Task<ActionResult<User>> GetUserById([FromBody] GetUserById request)
        {
            var user = await _mediator.Send(request);
            return user;
        }

    }
}

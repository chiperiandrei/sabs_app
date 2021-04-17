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
    public class UserController : ControllerBase
    {


        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetUsers()
        {
            var users = await _mediator.Send(new GetUsers());
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<User>> Create([FromBody] CreateUser request)
        {
            var user = await _mediator.Send(request);
            if (user != null)
                return user;
            else
                return BadRequest(
                "Email already exists"
            );
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _mediator.Send(new GetUserById(id));
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUser(id));
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ResponseLogin>> Login([FromBody] LoginUser request)
        {
            var loginObj = await _mediator.Send(request);
            if (loginObj == null)
            {
                return BadRequest("wrong email or password") ;
            }

            return new ObjectResult(loginObj);
        }


    }
}

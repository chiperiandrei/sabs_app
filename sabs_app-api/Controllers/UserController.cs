using MediatR;
using Microsoft.AspNetCore.Mvc;
using sabs_app_api.DTOs;
using sabs_app_api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sabs_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _mediator.Send(new GetUserById(id));
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            await _mediator.Send(new DeleteUser(id));
            return NoContent();
        }
        [HttpPost("addip")]
        public async Task<ActionResult<User>> AddIp([FromBody] AddIPAdress request)
        {
            var res = await _mediator.Send(request);
            return NoContent();
        }

    }
}

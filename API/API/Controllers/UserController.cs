﻿using Application.UsesCase.User.GetUserById;
using Application.UsesCase.User.GetUsersByType;
using Application.UsesCase.User.RegisterUser;
using Application.UsesCase.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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

        [HttpGet()]
        [Route("get-id")]
        public IActionResult GetById([FromQuery] GetUserByIdRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpGet()]
        [Route("get-type")]
        public IActionResult GetByTypeId([FromQuery] GetUsersByTypeRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPost()]
        [Route("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }

        [HttpPut()]
        [Route("update")]
        public IActionResult Update([FromBody] UpdateUserRequest request)
        {
            return Ok(_mediator.Send(request).Result);
        }
    }
}
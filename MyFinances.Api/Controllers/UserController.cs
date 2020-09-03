using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Core.Commands;
using MyFinances.Domain.Commands.UserCommands;
using MyFinances.Domain.Entities;
using MyFinances.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinances.Api.Controllers
{
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public UserController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        /// <summary>
        /// Get all users
        /// </summary>       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userService.GetAll();
            if (response != null || response.Any())
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// User by id
        /// </summary> 
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var response = await _userService.GetById(Id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Save User
        /// </summary>
        /// <param name="SaveUserCommand"></param>
        [HttpPost]
        public async Task<ActionResult<CommandResult<User>>> Post([FromBody] SaveUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="UpdateUserCommand"></param>
        [HttpPut]
        public async Task<ActionResult<CommandResult<User>>> Update([FromBody] UpdateUserCommand command)
        {
            //var command = new DeleteUserCommand(Id);
            var response = await _mediator.Send(command);
            if (response.Sucesso)
            {
                return Ok(response);

            }
            return BadRequest(response);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="DeleteUserCommand"></param>       
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CommandResult<User>>> Delete(int Id)
        {
            var command = new DeleteUserCommand(Id);
            var response = await _mediator.Send(command);
            if (response.Sucesso)
            {
                return Ok(response);

            }
            return BadRequest(response);
        }

        /// <summary>
        /// Validate User (Login)
        /// </summary>
        /// <param name="LoginUserCommand"></param>
        [HttpPost("VerificarUsuario")]
        public async Task<ActionResult<CommandResult<User>>> VerificarUsuario([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.Sucesso)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

    }
}

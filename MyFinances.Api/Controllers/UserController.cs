﻿using MediatR;
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
        /// Todos os usuários
        /// </summary>       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _userService.GetAll();
            if (response.Any())
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        /// <summary>
        /// Cadastrar usuario
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
        /// Excluir usuario
        /// </summary>
        /// <param name="DeleteUserCommand"></param>
        //[HttpGet("DeleteUser/{Id}")]
        [HttpDelete("{Id}")]
        public async Task<ActionResult<CommandResult<User>>> Delete(int Id)
        {
            //var response = await _mediator.Send(command);
            var response = await _userService.Delete(Id);
            if (response)
            {
                return Ok(response);

            }
            return BadRequest(response);
        }

        /// <summary>
        /// Verificar Usuario (Login)
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

using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using MyFinances.Core.Commands;
using MyFinances.Domain.Entities;
using MyFinances.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinances.Domain.Commands.UserCommands
{
    public class DeleteUserCommand : Notifiable, IRequest<CommandResult<User>>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires().IsNotNullOrEmpty(Id.ToString(), "ID", "Campo ID não pode ser vazio")
            );
        }
    }
}

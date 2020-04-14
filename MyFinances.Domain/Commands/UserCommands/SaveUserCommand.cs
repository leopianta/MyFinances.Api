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
    public class SaveUserCommand : Notifiable, IRequest<CommandResult<User>>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Nome, 1, "Nome", "Nome deve conter pelo menos 1 caracter")
                .HasMinLen(Email, 1, "Email", "Email deve conter pelo menos 1 caracter")
                .HasMinLen(Senha, 1, "Senha", "Senha deve conter pelo menos 1 caracter")
            );
        }
    }
}

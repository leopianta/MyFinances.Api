using Flunt.Notifications;
using MediatR;
using MyFinances.Core.Commands;
using MyFinances.Domain.Commands.UserCommands;
using MyFinances.Domain.Entities;
using MyFinances.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFinances.Domain.Handlers
{
    public class DeleteUserHandler : Notifiable, IRequestHandler<DeleteUserCommand, CommandResult<User>>
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<CommandResult<User>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResult<User>("Excluído com sucesso", true, null);
            request.Validate();
            if (request.Valid)
            {
                var user = _userRepository.GetById(request.Id);
                if (user != null && user.Id > 0)
                {
                    if (_userRepository.Delete(user.Id))
                    {
                        response.ObjetoResposta = user;
                        return Task.FromResult(response);
                    }
                    else
                    {
                        response.Sucesso = false;
                        response.Mensagem = "Não foi possível excluir este usuário.";
                        return Task.FromResult(response);
                    }
                    response.Notificacoes.AddRange(user.Notifications.Select(x => x.Message).ToList());
                }
            }
            response.Notificacoes.AddRange(request.Notifications.Select(x => x.Message).ToList());
            response.Sucesso = false;
            response.Mensagem = "Não foi possível excluir o usuário.";
            return Task.FromResult(response);
        }
    }
}

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
    public class UpdateUserHandler : Notifiable, IRequestHandler<UpdateUserCommand, CommandResult<User>>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<CommandResult<User>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResult<User>("Alterado com sucesso", true, null);
            request.Validate();
            if (request.Valid)
            {
                User user = new User(request.Nome, request.Email, request.Senha, request.TipoUsuario);
                if (user.Valid)
                {
                    var result = _userRepository.GetById(request.Id);
                    if (result != null && result.Id > 0)
                    {
                        user.Id = request.Id;
                        if (_userRepository.Update(user))
                        {
                            response.ObjetoResposta = user;
                            return Task.FromResult(response);
                        }

                        //response.Sucesso = false;
                        //response.Mensagem = "Usuário já cadastrado com esse nome e email.";
                        return Task.FromResult(response);
                    }
                    response.Notificacoes.AddRange(user.Notifications.Select(x => x.Message).ToList());
                }
            }
            response.Notificacoes.AddRange(request.Notifications.Select(x => x.Message).ToList());
            response.Sucesso = false;
            response.Mensagem = "Não foi possível alterar o usuário.";
            return Task.FromResult(response);
        }
    }
}

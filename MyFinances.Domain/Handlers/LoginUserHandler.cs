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
    public class LoginUserHandler : Notifiable, IRequestHandler<LoginUserCommand, CommandResult<User>>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<CommandResult<User>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResult<User>("Login realizado com sucesso", true, null);
            request.Validate();
            if (request.Valid)
            {
                User user = new User(request.Email, request.Senha);
                if (user.Valid)
                {
                    var result = _userRepository.GetAll().FirstOrDefault(x => x.email == request.Email && x.senha == request.Senha);
                    if (result != null)
                    {
                        response.Sucesso = true;
                        response.ObjetoResposta = result;
                        return Task.FromResult(response);
                    }
                    else {
                        response.Sucesso = false;
                        response.Mensagem = "Login ou senha inválidos!";
                        return Task.FromResult(response);
                    }
                }
                response.Notificacoes.AddRange(user.Notifications.Select(x => x.Message).ToList());
            }
            response.Notificacoes.AddRange(request.Notifications.Select(x => x.Message).ToList());
            response.Sucesso = false;
            response.Mensagem = "Não foi possível realizar o Login.";
            return Task.FromResult(response);
        }
    }
}

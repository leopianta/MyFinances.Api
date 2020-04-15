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
    public class SaveUserHandler : Notifiable, IRequestHandler<SaveUserCommand, CommandResult<User>>
    {
        private readonly IUserRepository _userRepository;
        public SaveUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<CommandResult<User>> Handle(SaveUserCommand request, CancellationToken cancellationToken)
        {
            var response = new CommandResult<User>("Salvo com sucesso", true, null);
            request.Validate();
            if (request.Valid)
            {
                User user = new User(request.Nome, request.Email, request.Senha, request.TipoUsuario);
                if (user.Valid)
                {
                    var result = _userRepository.GetList(x => x.nome == request.Nome && x.email == request.Email);
                    if (result != null && result.Any())
                    {
                        response.Sucesso = false;
                        response.Mensagem = "Usuário já foi cadastrado com esse nome e email.";
                        return Task.FromResult(response);
                    }
                    if (_userRepository.Insert(ref user))
                    {
                        response.ObjetoResposta = user;
                        return Task.FromResult(response);
                    }
                }
                response.Notificacoes.AddRange(user.Notifications.Select(x => x.Message).ToList());
            }
            response.Notificacoes.AddRange(request.Notifications.Select(x => x.Message).ToList());
            response.Sucesso = false;
            response.Mensagem = "Não foi possível cadastrar o usuário.";
            return Task.FromResult(response);
        }
    }
}

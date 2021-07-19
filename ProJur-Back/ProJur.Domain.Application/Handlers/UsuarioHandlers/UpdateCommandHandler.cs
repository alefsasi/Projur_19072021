using System;
using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using ProJur.Domain.Application.Commands;
using ProJur.Domain.Application.Commands.UsuarioCommands;
using ProJur.Domain.Application.Entities;
using ProJur.Domain.Application.Enums;
using ProJur.Domain.Application.Repositories;

namespace ProJur.Domain.Application.Handlers.UsuarioHandlers
{
    public class UpdateCommandHandler : Notifiable, IRequestHandler<UpdateCommand, CommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public UpdateCommandHandler(IMediator mediator, IUsuarioRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                if (request.Invalid)
                    return new CommandResult(false, "O Usuario é inválido", request.Notifications);

                var user = _repository.GetById(request.Id);

                if (user == null)
                    return new CommandResult(false, "Usuário não existe encontrado", request.Notifications);

                user.Nome = request.Nome;
                user.Sobrenome = request.Sobrenome;
                user.DataNascimento = request.DataNascimento;
                user.Email = request.Email;
                user.Escolaridade = (EscolaridadeEnum)request.Escolaridade;

                await _repository.Update(user);

                return new CommandResult(true, "Usuário Atualizado", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, "Ocorreu um erro genérico ao atualizar o Usuário", ex.Message);
            }
        }

    }
}
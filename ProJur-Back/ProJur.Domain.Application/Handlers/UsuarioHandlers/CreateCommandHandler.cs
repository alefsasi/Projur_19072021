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

    public class CreateCommandHandler : Notifiable, IRequestHandler<CreateCommand, CommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public CreateCommandHandler(IMediator mediator, IUsuarioRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                request.Validate();

                if (request.Invalid)
                    return new CommandResult(false, "O Usuario possui falhas.", request.Notifications);

                var user = new Usuario
                {
                    Nome = request.Nome,
                    Sobrenome = request.Sobrenome,
                    Email = request.Email,
                    DataNascimento = request.DataNascimento,
                    Escolaridade = (EscolaridadeEnum)request.Escolaridade
                };

                await _repository.Create(user);

                return new CommandResult(true, "Usuário Criado", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, "Ocorreu um erro genérico ao criar o Usuário", ex.Message);
            }
        }
    }
}
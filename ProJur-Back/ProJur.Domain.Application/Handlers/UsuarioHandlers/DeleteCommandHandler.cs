using System;
using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using ProJur.Domain.Application.Commands;
using ProJur.Domain.Application.Commands.UsuarioCommands;
using ProJur.Domain.Application.Entities;
using ProJur.Domain.Application.Repositories;

namespace ProJur.Domain.Application.Handlers.UsuarioHandlers
{
    public class DeleteCommandHandler : Notifiable, IRequestHandler<DeleteCommand, CommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public DeleteCommandHandler(IMediator mediator, IUsuarioRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {

            try
            {
                request.Validate();

                if (request.Invalid)
                    return new CommandResult(false, "O Usuario é inválido", request.Notifications);

                var user = _repository.GetById(request.Id);

                if (user == null)
                    return new CommandResult(false, "Usuário não existe encontrado", request.Notifications);

                await _repository.Delete(user);

                return new CommandResult(true, "Usuário Deletado", user);
            }
            catch (Exception ex)
            {
                return new CommandResult(false, "Ocorreu um erro genérico ao deletar o Usuário", ex.Message);
            }
        }
    }
}
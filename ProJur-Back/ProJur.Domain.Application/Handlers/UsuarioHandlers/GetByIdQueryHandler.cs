using System.Threading;
using System.Threading.Tasks;
using Flunt.Notifications;
using MediatR;
using ProJur.Domain.Application.Queries.UsuarioQueries;
using ProJur.Domain.Application.Entities;
using ProJur.Domain.Application.Repositories;
using ProJur.Domain.Application.Commands;

namespace ProJur.Domain.Application.Handlers.UsuarioHandlers
{
    public class GetByIdQueryHandler : Notifiable, IRequestHandler<GetByIdQuery, CommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public GetByIdQueryHandler(IMediator mediator, IUsuarioRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var usuarioRetornado = _repository.GetById(request.Id);

            if (usuarioRetornado == null)
                return await Task.FromResult<CommandResult>(new CommandResult(false, "O usuário não foi encontrado", request.Notifications));

            return await Task.FromResult<CommandResult>(new CommandResult(true, "Sucesso", usuarioRetornado));
        }
    }
}
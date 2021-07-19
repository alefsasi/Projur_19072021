using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ProJur.Domain.Application.Queries.UsuarioQueries;
using ProJur.Domain.Application.Entities;
using ProJur.Domain.Application.Repositories;
using System.Collections.Generic;
using Flunt.Notifications;
using ProJur.Domain.Application.Commands;
using System.Linq;

namespace ProJur.Domain.Application.Handlers.UsuarioHandlers
{
    public class GetAllQueryHandler :  Notifiable, IRequestHandler<GetAllQuery, CommandResult>
    {
        private readonly IMediator _mediator;
        private readonly IUsuarioRepository _repository;
        public GetAllQueryHandler(IMediator mediator, IUsuarioRepository repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<CommandResult> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var usuariosRetornados = _repository.GetAll();

            if (!usuariosRetornados.Any())
                return await Task.FromResult<CommandResult>(new CommandResult(false, "O não foram encontrados usuários no Banco", request.Notifications));

            return await Task.FromResult<CommandResult>(new CommandResult(true, "Sucesso", usuariosRetornados));
        }
    }
}
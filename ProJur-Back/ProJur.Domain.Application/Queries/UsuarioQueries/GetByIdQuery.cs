using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using ProJur.Domain.Application.Commands;
using ProJur.Domain.Application.Contracts;
using ProJur.Domain.Application.Entities;

namespace ProJur.Domain.Application.Queries.UsuarioQueries
{
    public class GetByIdQuery : Notifiable, ICommand, IRequest<CommandResult>
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract().Requires().IsTrue(Id > 0, "Id", "O Id do Usuário é inválido"));
        }
    }
}
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using ProJur.Domain.Application.Contracts;

namespace ProJur.Domain.Application.Commands.UsuarioCommands
{
    public class DeleteCommand : Notifiable, ICommand, IRequest<CommandResult>
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
           new Contract()
               .Requires()
               .IsTrue(Id > 0, "Id", "O Id do Usuário é inválido"));
        }
    }
}
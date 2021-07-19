using System;
using MediatR;
using ProJur.Domain.Application.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace ProJur.Domain.Application.Commands.UsuarioCommands
{
    public class CreateCommand : Notifiable, ICommand, IRequest<CommandResult>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }

        public void Validate()
        {
            AddNotifications(
                    new Contract()
                        .Requires()
                        .IsNotNullOrWhiteSpace(Nome, "Nome", "O nome precisa ser preenchido")
                        .HasMinLen(Nome, 3, "Nome", "O nome precisa ter mais que 3 caracteres")
                        .IsNotNullOrWhiteSpace(Sobrenome, "Sobrenome", "O Sobrenome precisa ser preenchido")
                        .HasMinLen(Sobrenome, 3, "Sobrenome", "O Sobrenome precisa ter mais que 3 caracteres")
                        .IsEmail(Email, "Email", "O e-mail Inserido é inválido")
                        .IsLowerThan(DataNascimento, DateTime.Now, "DataNascimento", "Data de Nascimento precisa ser menor que hoje"));
        }
    }
}
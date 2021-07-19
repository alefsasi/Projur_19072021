using System;
using System.Collections.Generic;
using Flunt.Notifications;
using MediatR;
using ProJur.Domain.Application.Commands;
using ProJur.Domain.Application.Contracts;
using ProJur.Domain.Application.Entities;

namespace ProJur.Domain.Application.Queries.UsuarioQueries
{
    public class GetAllQuery : Notifiable, ICommand, IRequest<CommandResult>
    {
        public GetAllQuery()
        {
        }

        public void Validate()
        {
        }
    }
}
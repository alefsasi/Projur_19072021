using ProJur.Domain.Application.Commands.Contracts;

namespace ProJur.Domain.Application.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message, object notifications = null)
        {
            this.Success = success;
            this.Message = message;
            this.Data = notifications;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
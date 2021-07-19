using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProJur.Domain.Application.Commands.UsuarioCommands;
using ProJur.Domain.Application.Queries.UsuarioQueries;

namespace ProJur.Domain.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            this._mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllQuery() ));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _mediator.Send(new GetByIdQuery{ Id = id } ));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
    
            var result = await _mediator.Send(new DeleteCommand { Id = id });
            return Ok(result);
        }
    }
}
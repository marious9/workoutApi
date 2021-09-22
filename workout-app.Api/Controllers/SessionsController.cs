using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using workout_app.Application.Commands;
using workout_app.Application.Mapping.Dto.Session;
using workout_app.Application.Queries;

namespace workout_app.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllSessions(CancellationToken cancellationToken)
        {
            var query = new GetAllSessions.GetAllSessionsQuery();
            List<SessionDto> result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSession
        (
            [FromBody] CreateSession.CreateSessionCommand command,
            CancellationToken cancellationToken
        )
        {
            int result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction("CreateSession", new { id = result });
        }
    }
}
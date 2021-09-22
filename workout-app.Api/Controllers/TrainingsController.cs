using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using workout_app.Application.Commands;

namespace workout_app.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingsController: ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTraining
        (
            [FromBody]CreateTraining.CreateTrainingCommand command,
            CancellationToken cancellationToken)
        {
            int result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction("CreateTraining", new { id = result });
        }

    }
}
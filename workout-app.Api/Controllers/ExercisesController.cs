using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using workout_app.Application.Commands;
using workout_app.Application.Mapping.Dto.Exercise;
using workout_app.Application.Queries;

namespace workout_app.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {      
        private readonly IMediator _mediator;

        public ExercisesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var query = new GetAllExercises.GetAllExercisesQuery();
            List<ExerciseDto> result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{exerciseId:int}")]
        public async Task<IActionResult> GetExerciseById(int exerciseId)
        {
            var query = new GetExerciseById.GetExerciseByIdQuery(exerciseId);
            ExerciseDto result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateExercise([FromBody] CreateExercise.CreateExerciseCommand command)
        {
            int result = await _mediator.Send(command);
            return CreatedAtAction("CreateExercise", new { id = result });
        }

    }
}

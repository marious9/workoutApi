using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using workout_app.Core.Domain;
using workout_app.Core.Domain.Helpers;
using workout_app.Data.Configuration;

namespace workout_app.Application.Commands
{
    public static class CreateTraining
    {
        public class CreateTrainingCommand : IRequest<int>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public HashSet<int> ExercisesIds { get; set; }
        }

        public class CreateTrainingHandler : IRequestHandler<CreateTrainingCommand, int>
        {
            private readonly WorkoutAppDbContext _dbContext;

            public CreateTrainingHandler(WorkoutAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
            {
                //todo in future add userId because training name should be unique by user
                bool trainingAlreadyExists = await _dbContext.Trainings
                                    .AnyAsync(x => x.Name == request.Name, cancellationToken)
                                    .ConfigureAwait(false);
                
                if (trainingAlreadyExists)
                {
                    throw new BusinessRuleValidationException($"Training with name {request.Name} already exists.");
                }

                List<Exercise> exercises = _dbContext.Exercises
                    .Where(x => request.ExercisesIds.Any(id => id == x.Id))
                    .ToList();

                if (exercises.Count != request.ExercisesIds.Count)
                {
                    throw new BusinessRuleValidationException("Some of exercises have not been found.");
                }

                var training = new Training
                {
                    Description = request.Description,
                    Name = request.Name,
                    Exercises = exercises
                };

                EntityEntry<Training> createdTraining = await _dbContext.Trainings
                    .AddAsync(training, cancellationToken);

                return training.Id;
            }
        }

        public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
        {
            public CreateTrainingCommandValidator()
            {
                RuleFor(x => x.Description).MaximumLength(500);
                RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
                RuleFor(x => x.ExercisesIds).NotEmpty();
            }
        }
    }
}
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using workout_app.Core.Domain;
using workout_app.Core.Domain.Helpers;
using workout_app.Data.Configuration;

namespace workout_app.Application.Commands
{
    public static class CreateExercise
    {
        public class CreateExerciseCommand : IRequest<int>
        {
            public string ExerciseType { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string VideoLink { get; set; }
            public string Category { get; set; }
            public ICollection<string> Subcategories { get; set; }
        }

        public class CreateExerciseHandler : IRequestHandler<CreateExerciseCommand, int>
        {
            private readonly WorkoutAppDbContext _dbContext;

            public CreateExerciseHandler(WorkoutAppDbContext dbContext)
            {
                _dbContext = dbContext;

            }
            
            public async Task<int> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
            {
                bool exerciseAlreadyExists = await _dbContext.Exercises
                    .AnyAsync(x => x.Name == request.Name, cancellationToken)
                    .ConfigureAwait(false);

                if (exerciseAlreadyExists)
                {
                    throw new BusinessRuleValidationException($"Exercise with name {request.Name} already exists");
                }

                var exercise = new Exercise
                {
                    Name = request.Name,
                    Description = request.Description,
                    VideoLink = request.VideoLink,
                    ExerciseType = (ExerciseType)Enum.Parse(typeof(ExerciseType), request.ExerciseType),
                    Category = (Category)Enum.Parse(typeof(Category), request.Category),
                    Subcategories = request.Subcategories.Select(x => new Subcategory
                    {
                        Category = (Category) Enum.Parse(typeof(Category), x)
                    }).ToList()
                };

                EntityEntry<Exercise> createdExercise = await _dbContext.Exercises
                    .AddAsync(exercise, cancellationToken);

                await _dbContext
                    .SaveChangesAsync(cancellationToken)
                    .ConfigureAwait(false);

                return createdExercise.Entity.Id;
            }
        }

        public class CreateExerciseCommandValidator : AbstractValidator<CreateExerciseCommand>
        {
            public CreateExerciseCommandValidator()
            {
                RuleFor(x => x.Description)
                    .MaximumLength(500);

                RuleFor(x => x.Name)
                    .MaximumLength(100)
                    .NotEmpty();

                RuleFor(x => x.Category)
                    .IsEnumName(typeof(Category))
                    .NotEmpty();
                
                RuleFor(x => x.ExerciseType)
                    .IsEnumName(typeof(ExerciseType))
                    .NotEmpty();
            }
        }
    }
}

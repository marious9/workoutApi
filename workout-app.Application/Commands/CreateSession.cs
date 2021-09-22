using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using workout_app.Core.Domain;
using workout_app.Core.Domain.Helpers;
using workout_app.Data.Configuration;

namespace workout_app.Application.Commands
{
    public static class CreateSession
    {
        public class CreateSessionCommand : IRequest<int>
        {
            public DateTime Date { get; set; }
            public ICollection<int> TrainingsIds { get; set; }
        }
        
        public class CreateSessionHandler : IRequestHandler<CreateSessionCommand, int>
        {
            private readonly WorkoutAppDbContext _dbContext;

            public CreateSessionHandler(WorkoutAppDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
            {
                // @todo for specific user
                var sessionExistsToday = _dbContext.Sessions
                    .Any(x => (x.DateTime - request.Date).Days == 0);

                if (sessionExistsToday)
                {
                    throw new BusinessRuleValidationException($"Session for Date: {request.Date:f} already exists");
                }

                var session = new Session
                {
                    DateTime = request.Date
                };

                EntityEntry<Session> dbSession = await _dbContext.Sessions.AddAsync(session, cancellationToken);

                return dbSession.Entity.Id;
            }

            public class CreateSessionCommandValidator : AbstractValidator<CreateSessionCommand>
            {
                public CreateSessionCommandValidator()
                {
                    RuleFor(x => x.Date).NotEmpty();
                }
            }
        }
    }
}
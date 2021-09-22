using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using workout_app.Application.Mapping.Dto.Session;
using workout_app.Core.Domain;
using workout_app.Data.Configuration;

namespace workout_app.Application.Queries
{
    public static class GetAllSessions
    {
        public class GetAllSessionsQuery : IRequest<List<SessionDto>>
        {
        }

        public class GetAllExercisesHandler : IRequestHandler<GetAllSessionsQuery, List<SessionDto>>
        {
            private readonly WorkoutAppDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetAllExercisesHandler(IMapper mapper, WorkoutAppDbContext dbContext)
            {
                _mapper = mapper;
                _dbContext = dbContext;
            }

            public async Task<List<SessionDto>> Handle(GetAllSessionsQuery request, CancellationToken cancellationToken)
            {
                List<Session> sessions = await _dbContext.Sessions
                    .ToListAsync(cancellationToken);

                var sessionDtos = _mapper.Map<List<SessionDto>>(sessions);

                return sessionDtos;
            }
        }
    }
}
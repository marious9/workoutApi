using AutoMapper;
using workout_app.Application.Mapping.Dto.Session;
using workout_app.Core.Domain;

namespace workout_app.Application.Mapping.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<Session, SessionDto>();
        }
    }
}
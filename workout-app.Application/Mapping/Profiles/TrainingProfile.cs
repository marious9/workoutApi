using AutoMapper;
using workout_app.Application.Mapping.Dto.Training;
using workout_app.Core.Domain;

namespace workout_app.Application.Mapping.Profiles
{
    public class TrainingProfile : Profile
    {
        public TrainingProfile()
        {
            CreateMap<Training, TrainingDto>();
        }
    }
}
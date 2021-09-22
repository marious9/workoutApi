using System;
using System.Collections.Generic;
using workout_app.Application.Mapping.Dto.Training;

namespace workout_app.Application.Mapping.Dto.Session
{
    public class SessionDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<TrainingDto> Trainings { get; set; }
    }
}
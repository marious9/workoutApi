using System.Collections.Generic;
using workout_app.Application.Mapping.Dto.Exercise;

namespace workout_app.Application.Mapping.Dto.Training
{
    public class TrainingDto
    {
        public int Id { get; }
        public string Description { get; set; }
        public ICollection<ExerciseDto> Exercises { get; set; }
    }
}
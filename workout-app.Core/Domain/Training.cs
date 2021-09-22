using System.Collections.Generic;

namespace workout_app.Core.Domain
{
    public class Training
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Session Session { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        public ICollection<UserTraining> UserTrainings { get; set; }
    }
}

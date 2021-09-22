using System;
using System.Collections.Generic;

namespace workout_app.Core.Domain
{
    public class Session
    {
        public int Id { get; }
        public DateTime DateTime { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        
    }
}

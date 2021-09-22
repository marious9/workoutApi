namespace workout_app.Core.Domain
{
    public class Entry
    {
        public int Id { get; }
        public int? Reps { get; set; }
        public double? Weight { get; set; }
        public int? TimeHeld { get; set; }
        public Exercise Exercise { get; set; }
    }
}

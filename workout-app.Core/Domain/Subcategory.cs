namespace workout_app.Core.Domain
{
    public class Subcategory
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public Exercise Exercise { get; set; }
    }
}

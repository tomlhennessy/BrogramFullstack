namespace BrogramApi.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
    }
}

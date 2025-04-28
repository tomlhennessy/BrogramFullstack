using System;
using System.Collections.Generic;

namespace BrogramApi.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty; // FK to AspNetUsers
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        public List<WorkoutExercise> WorkoutExercises { get; set; } = new();
    }
}


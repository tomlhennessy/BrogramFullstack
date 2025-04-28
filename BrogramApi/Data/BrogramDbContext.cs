using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BrogramApi.Models;

namespace BrogramApi.Data
{
    public class BrogramDbContext : IdentityDbContext<ApplicationUser>
    {
        public BrogramDbContext(DbContextOptions<BrogramDbContext> options) : base(options) {}

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure WorkoutExercise composite keys
            builder.Entity<WorkoutExercise>()
                .HasOne(we => we.Workout)
                .WithMany(w => w.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId);

            builder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId);
        }
    }
}

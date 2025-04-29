using BrogramApi.Data;
using BrogramApi.Models;
using BrogramApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrogramApi.Repositories.Implementations
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly BrogramDbContext _context;

        public WorkoutRepository(BrogramDbContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetWorkoutsByUserIdAsync(string userId)
        {
            return await _context.Workouts
                .Where(w => w.UserId == userId)
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .ToListAsync();
        }

        public async Task<Workout?> GetWorkoutByIdAsync(int id)
        {
            return await _context.Workouts
                .Include(w => w.WorkoutExercises)
                    .ThenInclude(we => we.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            await _context.Workouts.AddAsync(workout);
        }

        public async Task DeleteWorkoutAsync(Workout workout)
        {
            _context.Workouts.Remove(workout);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

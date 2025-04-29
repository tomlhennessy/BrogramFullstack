using BrogramApi.Models;
using BrogramApi.Repositories.Interfaces;

namespace BrogramApi.Services
{
    public class WorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutService(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        public async Task<List<Workout>> GetUserWorkoutsAsync(string userId)
        {
            return await _workoutRepository.GetWorkoutsByUserIdAsync(userId);
        }

        public async Task<Workout?> GetWorkoutAsync(int id)
        {
            return await _workoutRepository.GetWorkoutByIdAsync(id);
        }

        public async Task AddWorkoutAsync(Workout workout)
        {
            await _workoutRepository.AddWorkoutAsync(workout);
            await _workoutRepository.SaveChangesAsync();
        }

        public async Task DeleteWorkoutAsync(int id)
        {
            var workout = await _workoutRepository.GetWorkoutByIdAsync(id);
            if (workout != null)
            {
                await _workoutRepository.DeleteWorkoutAsync(workout);
                await _workoutRepository.SaveChangesAsync();
            }
        }
    }
}

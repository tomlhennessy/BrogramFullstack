using BrogramApi.Models;

namespace BrogramApi.Repositories.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetWorkoutsByUserIdAsync(string userId);
        Task<Workout?> GetWorkoutByIdAsync(int id);
        Task AddWorkoutAsync(Workout workout);
        Task DeleteWorkoutAsync(Workout workout);
        Task SaveChangesAsync();
    }
}

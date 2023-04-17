using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data.Interfaces
{
    public interface IDashboardRepsoitory
    {
        Task<List<Workout>> GetAllUserWorkouts();
        Task<List<Gym>> GetAllUserGyms();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();

    }
}

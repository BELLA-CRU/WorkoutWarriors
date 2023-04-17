using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data.Interfaces
{
    public interface IDashboardRepsoitory
    {
        Task<List<Workout>> GetAllUserWorkouts();
        Task<List<Gym>> GetAllUserGyms();
    }
}

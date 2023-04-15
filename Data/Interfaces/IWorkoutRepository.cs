using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data.Interfaces
{
    public interface IWorkoutRepository
    {

        Task<IEnumerable<Workout>> GetAll();

        Task<Workout> GetByIdAsync(int id);
        Task<IEnumerable<Workout>> GetClubByCity(string city);
        bool Add(Workout Workout);
        bool Update(Workout Workout);
        bool Delete(Workout Workout);
        bool Save();

    }
}

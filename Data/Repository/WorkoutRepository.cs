using Microsoft.EntityFrameworkCore;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {

        private readonly ApplicationDbContext _context;
        public WorkoutRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Workout Workout)
        {
            _context.Add(Workout);
            return Save();
        }

        public bool Delete(Workout Workout)
        {
            _context.Remove(Workout);
            return Save();
        }

        public async Task<IEnumerable<Workout>> GetAll()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout> GetByIdAsync(int id)
        {
            return await _context.Workouts.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Workout>> GetClubByCity(string city)
        {
            return await _context.Workouts.Where(c => c.Address.City.Contains(city)).ToListAsync(); ;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Workout Workout)
        {
           _context.Update(Workout);
            return Save();
        }
    }
}

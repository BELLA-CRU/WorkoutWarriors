using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Data.Repository
{
    public class GymRepository : IGymRepository
    {
        private readonly ApplicationDbContext _context;
        public GymRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Gym gym)
        {
           _context.Add(gym);
            return Save();
        }

        public bool Delete(Gym gym)
        {
            _context.Remove(gym);
            return Save();
        }

        public async Task<IEnumerable<Gym>> GetAll()
        {
            return await _context.Gyms.ToListAsync();
        }

        public async Task<Gym> GetByIdAsync(int id)
        {
            return await _context.Gyms.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Gym>> GetClubByCity(string city)
        {
           return await _context.Gyms.Where(c => c.Address.City.Contains(city)).ToListAsync(); ;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Gym gym)
        {
           _context.Update(gym);
            return Save();
        }
    }
}

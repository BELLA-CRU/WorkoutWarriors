using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Models;

namespace WorkoutWarriors.Data.Repository
{
    public class DashboardRepository : IDashboardRepsoitory
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) 
        { 
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Gym>> GetAllUserGyms()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userGyms =  _context.Gyms.Where(r => r.AppUser.Id == curUser);

            return userGyms.ToList();
        }

        public async Task<List<Workout>> GetAllUserWorkouts()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userWorkouts = _context.Workouts.Where(r => r.AppUser.Id == curUser);

            return userWorkouts.ToList();
        }
    }
}

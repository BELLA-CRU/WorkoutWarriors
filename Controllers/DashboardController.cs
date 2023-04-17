using Microsoft.AspNetCore.Mvc;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Data.Repository;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepsoitory _dashboardRepository;

        public DashboardController(IDashboardRepsoitory dashboardRepsoitory)
        {
            _dashboardRepository = dashboardRepsoitory;
        }

        public async Task<IActionResult> Index()
        {
            var userGyms = await _dashboardRepository.GetAllUserGyms();
            var userWorkouts = await _dashboardRepository.GetAllUserWorkouts();

            var dashboardViewModel = new DashboardViewModel()
            {
                Gyms = userGyms,
                Workouts = userWorkouts,

            };
            return View(dashboardViewModel);
        }
    }
}

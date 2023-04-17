using Microsoft.AspNetCore.Mvc;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Data.Repository;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepsoitory _dashboardRepository;
        private readonly IHttpContextAccessor  _httpContextAccessor;

        public DashboardController(IDashboardRepsoitory dashboardRepsoitory, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardRepository = dashboardRepsoitory;
            _httpContextAccessor = httpContextAccessor;
        }

        private static void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM)
        {
            user.Id = editVM.Id;
            user.MaxBenchPress = editVM.MaxBenchPress;
            user.MaxDeadlift = editVM.MaxDeadLift;
            user.Image = editVM.Image;
            user.City = editVM.City;
            user.State = editVM.State;

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

        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardRepository.GetUserById(curUserId);

            if (user == null) return View("Error");

            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = user.Id,
                MaxBenchPress = user.MaxBenchPress,
                MaxDeadLift = user.MaxDeadlift,
                Image = user.Image,
                City = user.City,
                State = user.State

            };
            return View(editUserViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);

            }

            AppUser user = await _dashboardRepository.GetByIdNoTracking(editVM.Id);

            MapUserEdit(user, editVM);

            _dashboardRepository.Update(user);

            return RedirectToAction("Index", "Dashboard");

            
        }
    }
}

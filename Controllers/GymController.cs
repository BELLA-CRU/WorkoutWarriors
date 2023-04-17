using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Data.Repository;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class GymController : Controller
    {
       
        private readonly IGymRepository _gymRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GymController(IGymRepository gymRepository, IHttpContextAccessor httpContextAccessor)
        {
            _gymRepository = gymRepository;
            _httpContextAccessor = httpContextAccessor;


        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Gym> gyms =await _gymRepository.GetAll(); 
            return View(gyms);
        }

        public async Task<IActionResult> Detail(int id)
        {

            Gym gym = await _gymRepository.GetByIdAsync(id);

            return View(gym);

        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();

            var createGymViewModel = new CreateGymViewModel {AppUserId = curUserId };

            return View(createGymViewModel);

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGymViewModel gymVM)
        {
            if (ModelState.IsValid)
            {
               
                var gym = new Gym
                {

                    Title = gymVM.Title,
                    Description = gymVM.Description,
                    Image = gymVM.Image,
                    GymType = gymVM.GymType,
                    AppUserId = gymVM.AppUserId,
                    Address = new Address
                    {
                        Street = gymVM.Address.Street,
                        City = gymVM.Address.City,
                        State = gymVM.Address.State

                    }


                };
                _gymRepository.Add(gym);

                return RedirectToAction("Index");
            }

            
            return View("Index");


        }
       
        public async Task<IActionResult> Edit(int id)
        {
            var gym= await _gymRepository.GetByIdAsync(id);
            if (gym == null) return View("Error");
            var gymVM = new EditGymViewModel
            {
                Title = gym.Title,
                Description = gym.Description,
                AddressId = gym.AddressId,
                Address = gym.Address,
                gymType = gym.GymType,
                Image = gym.Image


            };
            return View(gymVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditGymViewModel gymVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Gym");
                return View(gymVM);

            }

            var gym = new Gym
            {
                Id = id,
                Title = gymVM.Title,
                Description = gymVM.Description,
                AddressId = gymVM.AddressId,
                Address = gymVM.Address,
                GymType = gymVM.gymType,
                Image = gymVM.Image


            };

            _gymRepository.Update(gym);

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Delete(int id)
        {
                
            var gymDetails = await _gymRepository.GetByIdAsync(id);
            if (gymDetails == null) return View("Error");
            return View(gymDetails);

        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteGym(int id)
        {
            var GymDetails = await _gymRepository.GetByIdAsync(id);
            if (GymDetails == null) return View("Error");

            _gymRepository.Delete(GymDetails);
            return RedirectToAction("Index");

        }
    }
}

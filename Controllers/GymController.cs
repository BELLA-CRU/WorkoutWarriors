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
        public GymController(IGymRepository gymRepository)
        {
            _gymRepository = gymRepository;


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

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Gym gym)
        {
            if(!ModelState.IsValid)
            {
                return View(gym);

            }

            _gymRepository.Add(gym);

            return RedirectToAction("Index");


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
    }
}

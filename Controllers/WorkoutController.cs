using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Data.Repository;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class WorkoutController : Controller
    {

        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Workout> workouts = await _workoutRepository.GetAll();
            return View(workouts);
        }

        public async Task<IActionResult> Detail(int id)
        {

            Workout workout = await _workoutRepository.GetByIdAsync(id);

            return View(workout);

        }

        public IActionResult Create()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return View(workout);
            }

            _workoutRepository.Add(workout);

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Edit(int id)
        {
            var Workout = await _workoutRepository.GetByIdAsync(id);
            if (Workout == null) return View("Error");
            var WorkoutVM = new EditWorkoutViewModel
            {
                Title = Workout.Title,
                Description = Workout.Description,
                AddressId = Workout.AddressId,
                Address = Workout.Address,
                WorkoutType = Workout.WorkoutType,
                Image = Workout.Image,
                EntryFee = Workout.EntryFee,
                Website = Workout.Website,
                Twitter = Workout.Twitter,
                Facebook = Workout.Facebook


            };
            return View(WorkoutVM);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditWorkoutViewModel WorkoutVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit Workout");
                return View(WorkoutVM);

            }

            var Workout = new Workout
            {
                Id = id,
                Title = WorkoutVM.Title,
                Description = WorkoutVM.Description,
                AddressId = WorkoutVM.AddressId,
                Address = WorkoutVM.Address,
                WorkoutType = WorkoutVM.WorkoutType,
                Image = WorkoutVM.Image,
                EntryFee = WorkoutVM.EntryFee,
                Website = WorkoutVM.Website,
                Twitter = WorkoutVM.Twitter,
                Facebook = WorkoutVM.Facebook


            };

            _workoutRepository.Update(Workout);

            return RedirectToAction("Index");


        }
    }
}


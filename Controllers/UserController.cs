﻿using Microsoft.AspNetCore.Mvc;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Data.Repository;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        [HttpGet("users")]
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllUsers();
            List<UserViewModel> result = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = new UserViewModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    MaxBenchPress = user.MaxBenchPress,
                    MaxDeadLift = user.MaxDeadlift,
                    Image = user.Image
                };

                result.Add(userViewModel);
            }

            return View(result);
        }

        public async Task<IActionResult> Detail(string id)
        {

            var user = await _userRepository.GetUserById(id);

            var userDetailViewModel = new UserDetailViewModel()
            {
                Id = user.Id,
                UserName = user.UserName,
                MaxBenchPress = user.MaxBenchPress,
                MaxDeadLift = user.MaxDeadlift,
                City = user.City,
                State = user.State,
                Image = user.Image

            };

            return View(userDetailViewModel);
        }


    }
}

    


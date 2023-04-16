using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkoutWarriors.Data;
using WorkoutWarriors.Data.Enum;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;

namespace WorkoutWarriors.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        public IActionResult Login()
        {
            var response = new LoginViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginViewModel)
        {
            if (!ModelState.IsValid) return View(LoginViewModel);
           
                var user = await _userManager.FindByEmailAsync(LoginViewModel.EmailAddress);

                //Check if user is found
                if (user != null)
                {
                    //User is found, move on to check password
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, LoginViewModel.Password);

                    //Check password
                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, LoginViewModel.Password, false, false);

                        //Password is correct, sign in 
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Gym");

                        }

                        //Password is incorrect
                        TempData["Error"] = "Wrong Credentials. Please, try again";
                        return View(LoginViewModel);

                    }

                    //User was not found
                    TempData["Error"] = "Wrong Credentials. Please, try again";
                    return View(LoginViewModel);

                }

            //If all else fails, just return the model
            return View(LoginViewModel);
        }


        public IActionResult Register()
        {
            var response = new RegisterViewModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);

            if(user != null)
            {
                TempData["Error"] = "This email address is already in use, please login or try again";
                return View(registerViewModel);
            }

            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress

            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            }

            return RedirectToAction("Index", "Gym");


        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
             
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Gym");

        }



    }
            
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Globalization;
using System.Net;
using WorkoutWarriors.Data.Interfaces;
using WorkoutWarriors.Helpers;
using WorkoutWarriors.Models;
using WorkoutWarriors.View_Model;
using Xunit.Abstractions;

namespace WorkoutWarriors.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGymRepository _gymRepository;

        public HomeController(ILogger<HomeController> logger, IGymRepository gymRepository)
        {
            _logger = logger;
            _gymRepository = gymRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ipinfo = new IPInfo();
            var homeViewModel = new HomeViewModel();

            try
            {
                string url = "https://ipinfo.io?token=9b6cddf8474adf";
                var info = new WebClient().DownloadString(url);
                ipinfo = JsonConvert.DeserializeObject<IPInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipinfo.Country);
                ipinfo.Country = myRI1.EnglishName;
                homeViewModel.City = ipinfo.City;
                homeViewModel.State = ipinfo.Region;
                if(homeViewModel.City != null)
                {

                    homeViewModel.Gyms = await _gymRepository.GetClubByCity(homeViewModel.City);

                }
                else
                {
                    homeViewModel.Gyms = null;
                }


            }
            catch(Exception ex) 
            {
                homeViewModel.Gyms = await _gymRepository.GetAll();

            }

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
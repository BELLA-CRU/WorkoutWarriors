using Microsoft.AspNetCore.Mvc;

namespace WorkoutWarriors.Controllers
{
    public class UserController : Controller
    {
        [HttpGet("users")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers
{
    [AllowAnonymous]
    public class HolidayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult International()
        {
            return View();
        }
        public IActionResult Nepal()
        {
            return View();
        }
        public IActionResult Dubai()
        {
            return View();
        }
        public IActionResult Uzbekistan()
        {
            return View();
        }
        public IActionResult Qatar()
        {
            return View();
        }
        public IActionResult Abudhabi()
        {
            return View();
        }
        public IActionResult Srilanka()
        {
            return View();
        }
    }
}

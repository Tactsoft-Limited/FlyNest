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
        public IActionResult Maldives()
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
        public IActionResult Thailand()
        {
            return View();
        }
        public IActionResult Singapore()
        {
            return View();
        }
        public IActionResult Malaysia()
        {
            return View();
        }
        public IActionResult Vietnam()
        {
            return View();
        }
        public IActionResult India()
        {
            return View();
        }
        public IActionResult Turkey()
        {
            return View();
        }
    }
}

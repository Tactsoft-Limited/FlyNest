using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

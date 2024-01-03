using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin
{
    public class FlightController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class DashboardController : Controller
{
    public IActionResult Index() { return View(); }
}

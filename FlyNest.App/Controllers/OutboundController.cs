using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers;

public class OutboundController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Nepal()
    {
        return View();
    }
}
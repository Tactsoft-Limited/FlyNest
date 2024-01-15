using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers;

[AllowAnonymous]
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
    public IActionResult Dubai()
    {
        return View();
    }
    public IActionResult Qatar()
    {
        return View();
    }

    public IActionResult India()
{
   return View();
}
    public IActionResult SaudiArabia()

    {
        return View();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers
{
    [AllowAnonymous]
    public class VisaProcessingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

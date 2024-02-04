using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers
{
    [AllowAnonymous]
    public class HotelsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}


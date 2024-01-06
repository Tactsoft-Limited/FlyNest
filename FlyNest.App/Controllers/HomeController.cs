using FlyNest.App.Models;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlyNest.App.Controllers
{
    [AllowAnonymous]
    public class HomeController(
        ILogger<HomeController> logger,
        IAirportRepository airportRepository,
        IFlightRepository flightRepository) : Controller
    {
        private readonly IAirportRepository _airportRepository = airportRepository;
        private readonly IFlightRepository _flightRepository = flightRepository;
        private readonly ILogger<HomeController> _logger = logger;

        public async Task<IActionResult> Index()
        {
            var list = new VmSearchFlight
            {
                DepatureAirportDropdown = await _airportRepository.DropdownAsync(),
                ArrivalAirportDropdown = await _airportRepository.DropdownAsync(),
            };

            return View(list);
        }

        public async Task<IActionResult> SearchFlight(VmSearchFlight vmSearch)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = await _flightRepository.SearchFlightAsync(vmSearch);
                    if(data != null)
                    {
                        return View(data);
                    }
                }
            } catch(Exception exception)
            {
                TempData["ErrorMessage"] = $"Error get flight: {exception.Message}";
            }

            vmSearch.DepatureAirportDropdown = await _airportRepository.DropdownAsync();
            vmSearch.ArrivalAirportDropdown = await _airportRepository.DropdownAsync();
            return View(vmSearch);
        }

        public IActionResult OurMission() { return View(); }
        public IActionResult OurVision() { return View(); }
        public IActionResult OurManagement() { return View(); }
        public IActionResult AboutUs() { return View(); }

        public IActionResult Privacy() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
    }
}

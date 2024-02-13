using AutoMapper;
using FlyNest.App.Models;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlyNest.App.Controllers
{
    [AllowAnonymous]
    public class HomeController(
        ILogger<HomeController> logger,
        IAirportRepository airportRepository,
        IFlightRepository flightRepository,
        IHotelRepository hotelRepository,
        IFlightReservationRepository flightReservationRepository,
        IMapper mapper,
        IHotelReservationRepository hotelReservationRepository,
        IImageSliderRepository sliderRepository) : Controller
    {
        private readonly IFlightReservationRepository _flightReservationRepository = flightReservationRepository;
        private readonly IHotelReservationRepository _hotelReservationRepository = hotelReservationRepository;
        private readonly IAirportRepository _airportRepository = airportRepository;
        private readonly IFlightRepository _flightRepository = flightRepository;
        private readonly IHotelRepository _hotelRepository = hotelRepository;
        private readonly IImageSliderRepository _sliderRepository = sliderRepository;
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public IActionResult Index()
        {
            var viewModel = new VmReservation(); // Initialize ViewModel
            viewModel.ImageSlider = _mapper.Map<List<VmImageSlider>>(_sliderRepository.GetAll().OrderBy(x => x.Priority).Where(x => x.IsActive == true));
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlightReservation(VmReservation viewModel)
        {
            if (ModelState.IsValid)
            {
                await _flightReservationRepository.InsertAsync(
                    _mapper.Map<FlightReservation>(viewModel.FlightReservation));
                TempData["SuccessMessage"] = $" Flight booking successfully completed.";
                return RedirectToAction("Index");
            }
            return View("Index", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHotelReservation(VmReservation viewModel)
        {
            if (ModelState.IsValid)
            {
                await _hotelReservationRepository.InsertAsync(_mapper.Map<HotelReservation>(viewModel.HotelReservation));
                TempData["SuccessMessage"] = $" Hotel booking successfully completed.";
                return RedirectToAction("Index");
            }
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchFlight(VmSearchFlight vmSearch)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vmSearch.FlightList = await _flightRepository.SearchFlightAsync(vmSearch);
                    if (vmSearch.FlightList != null)
                    {
                        return View(vmSearch.FlightList);
                    }
                }
            }
            catch (Exception exception)
            {
                TempData["ErrorMessage"] = $"Error get flight: {exception.Message}";
            }

            vmSearch.DepatureAirportDropdown = await _airportRepository.DropdownAsync();
            vmSearch.ArrivalAirportDropdown = await _airportRepository.DropdownAsync();
            return View(vmSearch);
        }

        [HttpPost]
        public async Task<IActionResult> SearchHotel(VmSearchFlight vmSearch)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vmSearch.HotelList = await _hotelRepository.SearchHotelAsync(vmSearch);
                    if (vmSearch.HotelList != null)
                    {
                        return View(vmSearch.HotelList);
                    }
                }
            }
            catch (Exception exception)
            {
                TempData["ErrorMessage"] = $"Error get flight: {exception.Message}";
            }

            vmSearch.HotelDropdown = await _hotelRepository.DropdownAsync();
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

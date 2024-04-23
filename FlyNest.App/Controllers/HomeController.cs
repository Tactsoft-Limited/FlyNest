using AutoMapper;
using FlyNest.App.Models;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        IImageSliderRepository sliderRepository,
        ICountryRepository countryRepository,
        ITourPackageRepository tourPackageRepository,
        IVisaRequirementRepository visaRequirementRepository,
        IVisaRequestRepository visaRequest,
        IImageGalleryRepository galleryRepository,
        IFaqRepository faqRepository) : Controller
    {
        private readonly IFlightReservationRepository _flightReservationRepository = flightReservationRepository;
        private readonly IHotelReservationRepository _hotelReservationRepository = hotelReservationRepository;
        private readonly IAirportRepository _airportRepository = airportRepository;
        private readonly IFlightRepository _flightRepository = flightRepository;
        private readonly IHotelRepository _hotelRepository = hotelRepository;
        private readonly IImageSliderRepository _sliderRepository = sliderRepository;
        private readonly ICountryRepository _countryRepository = countryRepository;
        private readonly ITourPackageRepository _tourPackageRepository = tourPackageRepository;
        private readonly IVisaRequirementRepository _visaRequirementRepository = visaRequirementRepository;
        private readonly IVisaRequestRepository _visaRequest = visaRequest;
        private readonly IImageGalleryRepository _galleryRepository = galleryRepository;
        private readonly IFaqRepository _faqRepository = faqRepository;
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IMapper _mapper = mapper;

        public IActionResult Index()
        {
            var viewModel = new VmReservation
            {
                ImageSlider = _mapper.Map<List<VmImageSlider>>(_sliderRepository.GetAll().OrderBy(x => x.Priority).Where(x => x.IsActive == true)),
                CountryList = _mapper.Map<List<VmCountry>>(_countryRepository.GetAll().OrderBy(x => x.Id).Take(8)),
                ExploreBDList = _mapper.Map<List<VmTourPackage>>(_tourPackageRepository.GetAll().Where(x => x.PackageType == PackageType.ExploreBD).Take(8)),
                CountryDropdown = _countryRepository.Dropdown()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlightReservation(VmReservation viewModel)
        {
            if (ModelState.IsValid)
            {
                await _flightReservationRepository.InsertAsync(_mapper.Map<FlightReservation>(viewModel.FlightReservation));
                TempData["SuccessMessage"] = $"Request successfull for flight booking.";
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
                TempData["SuccessMessage"] = $"Request successfull for hotel booking.";
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

        public async Task<IActionResult> CountryDetails(long id)
        {
            var country = await _countryRepository.FirstOrDefaultAsync(id);
            return View(_mapper.Map<VmCountry>(country));
        }

        [HttpGet]
        public async Task<IActionResult> VisaProcessRequest(VmReservation viewModel)
        {
            var id = await _visaRequirementRepository.GetAll().Where(x => x.CountryId == viewModel.VmVisaProcessRequest.CountryId).Select(x => x.Id).FirstOrDefaultAsync();
            var result = await _visaRequirementRepository.FirstOrDefaultAsync(id, x => x.Country);
            viewModel.VmVisaRequirement = _mapper.Map<VmVisaRequirement>(result);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> VisaBooking(long id)
        {
            var visa = await _visaRequirementRepository.FirstOrDefaultAsync(id);
            return View();
        }

        [HttpGet]
        public IActionResult ServiceRequest()
        {
            return View(new VmVisaRequest());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ServiceRequest(VmVisaRequest vmRequest)
        {
            if (ModelState.IsValid)
            {
                await _visaRequest.InsertAsync(_mapper.Map<VisaRequest>(vmRequest));
                TempData["SuccessMessage"] = $" Request successfully submitted.";
                return RedirectToAction("ServiceRequest");
            }
            return View();
        }

        public async Task<IActionResult> FaqAndSupport()
        {
            var faqList = await _faqRepository.GetAllAsync();
            return View(_mapper.Map<List<VmFaq>>(faqList));
        }

        public IActionResult OurMission() { return View(); }
        public IActionResult OurVision() { return View(); }
        public IActionResult OurManagement() { return View(); }
        public IActionResult AboutUs() { return View(); }

        public async Task<IActionResult> ImageGalleryAsync()
        {
            var imageList = await _galleryRepository.GetAllAsync();
            return View(_mapper.Map<List<VmImageGallery>>(imageList));
        }

        public IActionResult Privacy() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        { return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
    }
}

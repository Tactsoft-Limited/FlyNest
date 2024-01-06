using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class FlightController(
    IFlightRepository flightRepository,
    IAirlineRepository airlineRepository,
    IAirportRepository airportRepository,
    IMapper mapper) : Controller
{
    private readonly IFlightRepository _flightRepository = flightRepository;
    private readonly IAirlineRepository _airlineRepository = airlineRepository;
    private readonly IAirportRepository _airportRepository = airportRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var flights = await _flightRepository.GetAllAsync(x => x.Airline, x => x.DepatureFlight, x => x.ArrivalFlight);
        return View(_mapper.Map<List<VmFlight>>(flights));
    }

    // GET: Flight/Details/5
    public async Task<IActionResult> DetailsAsync(long id)
    {
        if(id <= 0)
        {
            return NotFound();
        }
        var flight = await _flightRepository.FirstOrDefaultAsync(
            id,
            x => x.Airline,
            x => x.DepatureFlight,
            x => x.ArrivalFlight,
            x => x.Stopovers);

        return flight == null ? NotFound() : View(_mapper.Map<VmFlight>(flight));
    }

    // GET: Flight/Create
    public async Task<IActionResult> Create()
    {
        var vmFlight = new VmFlight
        {
            AirlineDropdown = await _airlineRepository.GetDropdownAsync(),
            AirportDropdown = await _airlineRepository.GetDropdownAsync(),
        };
        return View(vmFlight);
    }

    // POST: Flight/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VmFlight vmFlight)
    {
        if(ModelState.IsValid)
        {
            var flight = _mapper.Map<Flight>(vmFlight);
            await _flightRepository.InsertAsync(flight);
            return RedirectToAction(nameof(Index));
        }
        vmFlight.AirlineDropdown = await _airlineRepository.GetDropdownAsync();
        vmFlight.AirlineDropdown = await _airlineRepository.GetDropdownAsync();
        return View(vmFlight);
    }

    // GET: Flight/Edit/5
    public async Task<IActionResult> Edit(long id)
    {
        if(id <= 0)
        {
            return NotFound();
        }

        var flight = await _flightRepository.FirstOrDefaultAsync(id);
        if(flight == null)
        {
            return NotFound();
        }

        var vmFlight = new VmFlight
        {
            AirlineDropdown = await _airlineRepository.GetDropdownAsync(),
            AirportDropdown = await _airlineRepository.GetDropdownAsync(),
        };

        return View(vmFlight);
    }
}

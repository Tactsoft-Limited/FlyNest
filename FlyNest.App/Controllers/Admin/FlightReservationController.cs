using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class FlightReservationController(IFlightReservationRepository flightReservationRepository, IMapper mapper) : Controller
{
    private readonly IFlightReservationRepository _flightReservationRepository = flightReservationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var list = await _flightReservationRepository.GetAllAsync();
        return View(_mapper.Map<List<VmFlightReservation>>(list));
    }

    // GET: Flight/Details/5
    public async Task<IActionResult> Details(long id)
    {
        var flight = await _flightReservationRepository.FirstOrDefaultAsync(id);
        return flight == null ? NotFound() : View(_mapper.Map<VmFlightReservation>(flight));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmFlightReservation());
            default:
                var data = await _flightReservationRepository.FirstOrDefaultAsync(id);
                return View(_mapper.Map<VmFlightReservation>(data));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmFlightReservation viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                switch (ModelState.IsValid)
                {
                    case true:
                        var flight = _mapper.Map<FlightReservation>(viewModel);
                        await _flightReservationRepository.InsertAsync(flight);
                        return RedirectToAction(nameof(Index));
                }

                break;
            default:
                switch (ModelState.IsValid)
                {
                    case true:
                        var flight = _mapper.Map<FlightReservation>(viewModel);
                        await _flightReservationRepository.UpdateAsync(flight);
                        return RedirectToAction(nameof(Index));
                }

                break;
        }

        return View(viewModel);
    }
}

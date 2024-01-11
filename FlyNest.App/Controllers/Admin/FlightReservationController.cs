using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
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
}

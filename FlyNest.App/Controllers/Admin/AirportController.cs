using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class AirportController(IAirportRepository airportRepository, IMapper mapper) : Controller
{
    private readonly IAirportRepository _airportRepository = airportRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var list = await _airportRepository.GetAllAsync();
        return View(_mapper.Map<List<VmAirport>>(list));
    }
}

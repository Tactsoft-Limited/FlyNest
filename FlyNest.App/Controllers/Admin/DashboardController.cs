using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities.Search;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.App.Controllers.Admin;

public class DashboardController(
    IFlightReservationRepository flightReservationRepository,
    IHotelReservationRepository hotelReservationRepository) : Controller
{
    private readonly IFlightReservationRepository _flightReservationRepository = flightReservationRepository;
    private readonly IHotelReservationRepository _hotelReservationRepository = hotelReservationRepository;

    public async Task<IActionResult> Index()
    {
        var dashboard = new VmDashboard
        {
            TotalFlightReserve = await _flightReservationRepository.GetAll().CountAsync(),
            TotalHotelReserve = await _hotelReservationRepository.GetAll().CountAsync(),
        };
        return View(dashboard);
    }
}

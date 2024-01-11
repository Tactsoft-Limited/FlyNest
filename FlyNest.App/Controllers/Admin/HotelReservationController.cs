using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class HotelReservationController(IHotelReservationRepository hotelReservationRepository, IMapper mapper) : Controller
{
    private readonly IHotelReservationRepository _hotelReservationRepository = hotelReservationRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var list = await _hotelReservationRepository.GetAllAsync();
        return View(_mapper.Map<List<VmHotelReservation>>(list));
    }
}

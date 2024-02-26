using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class ConfirmBookingController(IConfirmBookingRepository confirmBookingRepository, IMapper mapper) : Controller
{
    private readonly IConfirmBookingRepository _confirmBookingRepository = confirmBookingRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var bookingList = await _confirmBookingRepository.GetAllAsync();
        return View(_mapper.Map<List<VmConfirmBooking>>(bookingList));
    }
}

using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
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

    // GET: Flight/Details/5
    public async Task<IActionResult> Details(long id)
    {
        var hotel = await _hotelReservationRepository.FirstOrDefaultAsync(id);
        return hotel == null ? NotFound() : View(_mapper.Map<VmHotelReservation>(hotel));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmHotelReservation());
            default:
                var data = await _hotelReservationRepository.FirstOrDefaultAsync(id);
                return View(_mapper.Map<VmHotelReservation>(data));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmHotelReservation viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                switch (ModelState.IsValid)
                {
                    case true:
                        var hotel = _mapper.Map<HotelReservation>(viewModel);
                        await _hotelReservationRepository.InsertAsync(hotel);
                        return RedirectToAction(nameof(Index));
                }

                break;
            default:
                switch (ModelState.IsValid)
                {
                    case true:
                        var hotel = _mapper.Map<HotelReservation>(viewModel);
                        await _hotelReservationRepository.UpdateAsync(hotel);
                        return RedirectToAction(nameof(Index));
                }

                break;
        }

        return View(viewModel);
    }
}

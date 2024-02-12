using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class HotelController : Controller
{

    private readonly IHotelRepository _repository;
    private readonly IHotelImagesRepository _hotelImagesRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public HotelController(IHotelRepository repository, IHotelImagesRepository hotelImagesRepository, IFileStorageService fileStorageService, IMapper mapper)
    {
        _repository = repository;
        _hotelImagesRepository = hotelImagesRepository;
        _fileStorageService = fileStorageService;
        _mapper = mapper;
        CommonVariables.PictureLocation = "images/hotel";
    }

    [HttpGet]
    public async Task<IActionResult> Index()

    {
        var list = await _repository.GetAllAsync();
        return View(_mapper.Map<List<VmHotel>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmHotel());
            default:
                var data = await _repository.FirstOrDefaultAsync(id, x => x.HotelImages);
                return View(_mapper.Map<VmHotel>(data));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmHotel viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                if (ModelState.IsValid)
                {
                    if (viewModel.ImageFiles != null)
                    {
                        foreach (var file in viewModel.ImageFiles)
                        {
                            string savedImagePath = await _fileStorageService.SaveImageAsync(file);
                            viewModel.HotelImages.Add(new VmHotelImages { HotelImage = savedImagePath });
                        }
                    }
                    var hotel = _mapper.Map<Hotel>(viewModel);
                    await _repository.InsertAsync(hotel);
                    return RedirectToAction(nameof(Index));
                }
                break;

            default:
                if (ModelState.IsValid)
                {
                    if (viewModel.ImageFiles != null)
                    {
                        foreach (var file in viewModel.ImageFiles)
                        {
                            string savedImagePath = await _fileStorageService.SaveImageAsync(file);
                            viewModel.HotelImages.Add(new VmHotelImages { HotelImage = savedImagePath });
                        }
                    }
                    var hotel = _mapper.Map<Hotel>(viewModel);
                    await _repository.UpdateAsync(hotel);
                    return RedirectToAction(nameof(Index));
                }

                break;
        }

        return View(viewModel);
    }

    public async Task<IActionResult> Delete(long id)
    {
        switch (id)
        {
            case > 0:
                await _repository.DeleteAsync(id);
                TempData["SuccessMessage"] = $" Item remove successfully";
                return RedirectToAction("Index");
            default:
                TempData["ErrorMessage"] = $"Error delete : Item not found";
                return RedirectToAction("Index");
        }
    }
}

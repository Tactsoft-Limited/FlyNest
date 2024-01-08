using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class HotelController(
    IHotelRepository hotelRepository,
    IHotelImagesRepository hotelImagesRepository,
    IWebHostEnvironment webHostEnvironment,
    IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()=> View(mapper.Map<List<VmHotel>>(await hotelRepository.GetAllAsync()));
    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch(id)
        {
            case 0:
                return View(new VmHotel());
            default:
                var data = await hotelRepository.FirstOrDefaultAsync(id, x => x.HotelImages);
                return View(mapper.Map<VmHotel>(data));
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmHotel viewModel)
    {
        switch(viewModel.Id)
        {
            case 0:
                switch(ModelState.IsValid)
                {
                    case true:
                        var hotel = mapper.Map<Hotel>(viewModel);
                        await hotelRepository.InsertAsync(hotel);

                        if(viewModel.File != null)
                        {
                            foreach(var file in viewModel.File)
                            {
                                if(file != null && file.Length > 0)
                                {
                                    var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images/hotel");
                                    var fileName = $"{hotel.Id}_{Path.GetRandomFileName()}_{Path.GetFileName(file.FileName)}";
                                    var filePath = Path.Combine(uploads, fileName);

                                    await using(var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        await file.CopyToAsync(stream);
                                    }
                                    var hotelImage = new HotelImages { HotelId = hotel.Id, HotelImage = fileName };
                                    await hotelImagesRepository.InsertAsync(hotelImage);
                                    TempData["SuccessMessage"] = $" Hotel '{hotelImage.Hotel.Name}' added successfully.";
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                }
                break;
            default:
                switch(ModelState.IsValid)
                {
                    case true:
                        var hotel = mapper.Map<Hotel>(viewModel);
                        await hotelRepository.UpdateAsync(hotel);
                        if(viewModel.File != null)
                        {
                            foreach(var file in viewModel.File)
                            {
                                if(file != null && file.Length > 0)
                                {
                                    var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images/hotel");
                                    var fileName = $"{hotel.Id}_{Path.GetRandomFileName()}_{Path.GetFileName(file.FileName)}";
                                    var filePath = Path.Combine(uploads, fileName);
                                    await using(var stream = new FileStream(filePath, FileMode.Create))
                                    {
                                        await file.CopyToAsync(stream);
                                    }
                                    var hotelImage = new HotelImages { HotelId = hotel.Id, HotelImage = fileName };
                                    await hotelImagesRepository.UpdateAsync(hotelImage);
                                    TempData["SuccessMessage"] = $" Hotel '{hotelImage.Hotel.Name}' update successfully.";
                                }
                            }
                        }
                        return RedirectToAction(nameof(Index));
                }

                break;
        }

        return View(viewModel);
    }
    public async Task<IActionResult> Delete(long id)
    {
        switch(id)
        {
            case > 0:
                await hotelRepository.DeleteAsync(id);
                TempData["SuccessMessage"] = $" Item remove successfully";
                return RedirectToAction("Index");
            default:
                TempData["ErrorMessage"] = $"Error delete : Item not found";
                return RedirectToAction("Index");
        }
    }
}

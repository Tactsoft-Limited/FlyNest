using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class HotelController(IHotelRepository hotelRepository, IHotelImagesRepository hotelImagesRepository, IWebHostEnvironment webHostEnvironment, IMapper mapper) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await hotelImagesRepository.GetAllAsync(x=>x.Hotel);
        return View(mapper.Map<List<VmHotelImages>>(list));
    }
    [HttpGet]
    public async Task<IActionResult> AddEdit(string id)
    {
        if (!string.IsNullOrEmpty(id) && long.TryParse(id, out long hotelId))
        {
            var viewModel = await hotelImagesRepository.FirstOrDefaultAsync(hotelId,x=>x.Hotel);

            if (viewModel != null)
            {
                var mappedViewModel = mapper.Map<VmHotelImages>(viewModel);
                return View(mappedViewModel);
            }
        }

        return View(new VmHotelImages());
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit( VmHotelImages viewModel, List<IFormFile> hotelImages)
    {
        if (viewModel.Id==0)
        {
            if (ModelState.IsValid)
            {
                var hotel = mapper.Map<Hotel>(viewModel.Hotel);
                await hotelRepository.InsertAsync(hotel);
                foreach (var file in hotelImages)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images/hotel");
                        var fileName = $"{hotel.Id}_{Path.GetRandomFileName()}_{Path.GetFileName(file.FileName)}";
                        var filePath = Path.Combine(uploads, fileName);

                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var hotelImage = new HotelImages
                        {
                            HotelId = hotel.Id,
                            HotelImage = fileName
                        };
                        await hotelImagesRepository.InsertAsync(hotelImage);
                        TempData["SuccessMessage"] = $" Airport '{hotelImage.Hotel.Name}' added successfully.";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            if (ModelState.IsValid)
            {
                var hotel = mapper.Map<Hotel>(viewModel.Hotel);
                await hotelRepository.UpdateAsync(hotel);
                foreach (var file in hotelImages)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images/hotel");
                        var fileName = $"{hotel.Id}_{Path.GetRandomFileName()}_{Path.GetFileName(file.FileName)}";
                        var filePath = Path.Combine(uploads, fileName);
                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        var hotelImage = new HotelImages
                        {
                            HotelId = hotel.Id,
                            HotelImage = fileName
                        };
                        await hotelImagesRepository.UpdateAsync(hotelImage);
                        TempData["SuccessMessage"] = $" Airport '{hotelImage.Hotel.Name}' update successfully.";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
        }
        return View(viewModel);
    }


    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await hotelImagesRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

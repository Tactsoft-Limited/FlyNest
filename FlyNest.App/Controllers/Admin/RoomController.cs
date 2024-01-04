using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class RoomController(
    IRoomImagesRepository imagesRepository,
    IMapper mapper,
    IRoomRepository roomRepository,
    IWebHostEnvironment webHostEnvironment,IHotelRepository hotelRepository)
    : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await imagesRepository.GetAllAsync(x => x.Room, x => x.Room.Hotel);
        return View(mapper.Map<List<VmRoomImages>>(list));
    } 
    [HttpGet]
public async Task<IActionResult> AddEdit(long id)
{
    ViewData["HotelId"] = hotelRepository.Dropdown();
    if (id > 0)
    {
        var viewModel = await imagesRepository.FirstOrDefaultAsync(id, x => x.Room, x => x.Room.Hotel);

        if (viewModel != null)
        {
            var mappedViewModel = mapper.Map<VmRoomImages>(viewModel);
            return View(mappedViewModel);
        }
    }

    return View(new VmRoomImages());
}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmRoomImages viewModel, List<IFormFile> roomImages)
    {
        try
        {
            if (ModelState.IsValid)
            {
                // Map the ViewModel to Room entity
                var room = mapper.Map<Room>(viewModel.Room);

                if (viewModel.Id == 0)
                {
                    // Insert Data
                    await roomRepository.InsertAsync(room);
                }
                else
                {
                    // Update Data
                   await roomRepository.UpdateAsync(room);

                    // Delete existing room images
                    var existingRoomImages = await imagesRepository
                        .GetAllAsync(x => x.RoomId == room.Id);

                    foreach (var existingImage in existingRoomImages)
                    {
                        await imagesRepository.DeleteAsync(existingImage.Id);
                    }
                }

                // Upload and insert new room images
                foreach (var file in roomImages)
                {
                    if (file != null && file.Length > 0)
                    {
                        var uploads = Path.Combine(webHostEnvironment.WebRootPath, "images/room");
                        var fileName = $"{room.Id}_{Path.GetRandomFileName()}_{Path.GetFileName(file.FileName)}";
                        var filePath = Path.Combine(uploads, fileName);

                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        // Map the image details to RoomImages entity
                        var roomImage = new RoomImages
                        {
                            RoomId = room.Id,
                            RoomImage = fileName
                        };

                        // Insert new room image
                        await imagesRepository.InsertAsync(roomImage);
                    }
                }

                TempData["SuccessMessage"] = $" Room '{room.Name}' {(viewModel.Id == 0 ? "added" : "updated")} successfully.";
                return RedirectToAction(nameof(Index));
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
            TempData["ErrorMessage"] = $"An error occurred: {ex.Message}";
        }

        // If there's an error, redisplay the form with the ViewModel
        ViewData["HotelId"] = hotelRepository.Dropdown();
        return View(viewModel);
    }



    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await imagesRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
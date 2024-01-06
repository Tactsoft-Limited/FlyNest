using AutoMapper;
using FlyNest.Application.Repositories.Entities;
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
        var list = await roomRepository.GetAllAsync(x => x.RoomImages,x=>x.Hotel);
        return View(mapper.Map<List<VmRoom>>(list));
    }
    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["HotelId"] = await hotelRepository.DropdownAsync();
        switch (id)
        {
            case 0:
                return View(new VmRoom());
            default:
            {
                var data = await roomRepository.FirstOrDefaultAsync(id, x => x.RoomImages);
                return View(mapper.Map<VmRoom>(data));
            }
        }
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmRoom viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
            {
                switch (ModelState.IsValid)
                {
                    case true:
                    {
                        var room = mapper.Map<Room>(viewModel);
                        await roomRepository.InsertAsync(room);
                        foreach (var file in viewModel.Files)
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
                                var hotelImage = new RoomImages()
                                {
                                    RoomId = room.Id,
                                    RoomImage = fileName
                                };
                                await imagesRepository.InsertAsync(hotelImage);
                                TempData["SuccessMessage"] = $" Airport '{room.Name}' added successfully.";
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }

                break;
            }
            default:
            {
                switch (ModelState.IsValid)
                {
                    case true:
                    {
                        var room = mapper.Map<Room>(viewModel);
                        await roomRepository.UpdateAsync(room);
                        foreach (var file in viewModel.Files)
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
                                var hotelImage = new RoomImages()
                                {
                                    RoomId = room.Id,
                                    RoomImage = fileName
                                };
                                await imagesRepository.UpdateAsync(hotelImage);
                                TempData["SuccessMessage"] = $" Airport '{room.Name}' update successfully.";
                            }
                        }
                        return RedirectToAction(nameof(Index));
                    }
                }

                break;
            }
        }
        ViewData["HotelId"] = await hotelRepository.DropdownAsync();
        return View(viewModel);
    }


    public async Task<IActionResult> Delete(long id)
    {
        switch (id)
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
using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class AirlineController(IAirlineRepository airlineRepository, IMapper mapper) : Controller
{


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await airlineRepository.GetAllAsync();
        return View(mapper.Map<List<VmAirline>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
       
        return id switch
        {
            0 => View(new VmAirline()),
            _ => View(mapper.Map<VmAirline>(await airlineRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(int id, VmAirline airline, IFormFile pictureFile)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (pictureFile != null && pictureFile.Length > 0)
                        {
                            var path = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot/images/airline",
                                pictureFile.FileName);
                            await using (var stream = new FileStream(path, FileMode.Create))
                            {
                                pictureFile.CopyTo(stream);
                            }
                            airline.Logo = $"{pictureFile.FileName}";
                        }
                        await airlineRepository.InsertAsync(mapper.Map<Airline>(airline));
                        TempData["SuccessMessage"] = $" Airline added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Airline : {ex.Message}";
                }

                break;
            default:
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (pictureFile != null && pictureFile.Length > 0)
                        {
                            var path = Path.Combine(
                                Directory.GetCurrentDirectory(),
                                "wwwroot/images/airline",
                                pictureFile.FileName);
                            await using (var stream = new FileStream(path, FileMode.Create))
                            {
                                pictureFile.CopyTo(stream);
                            }
                            airline.Logo = $"{pictureFile.FileName}";
                        }

                        await airlineRepository.UpdateAsync(mapper.Map<Airline>(airline));
                        TempData["SuccessMessage"] = $" Airline update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Airline : {ex.Message}";
                }
                break;


        }

        

        return View(new VmAirline());
    }

    
    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await airlineRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

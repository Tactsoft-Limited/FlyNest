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
            _ => View(await airlineRepository.FirstOrDefaultAsync(id))
        };
    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(int id, VmAirline airline)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await airlineRepository.InsertAsync(mapper.Map<Airline>(airline));
                        TempData["SuccessMessage"] = $" Contractor '{airline.AirlineName}' added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Contractor '{airline.AirlineName}': {ex.Message}";
                }

                break;
            default:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await airlineRepository.UpdateAsync( mapper.Map<Airline>(airline));
                        TempData["SuccessMessage"] = $" Contractor '{airline.AirlineName}' update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Contractor '{airline.AirlineName}': {ex.Message}";
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

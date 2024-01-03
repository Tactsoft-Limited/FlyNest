using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace FlyNest.App.Controllers.Admin;

public class AirportController(IAirportRepository airportRepository, IMapper mapper) : Controller
{


    public async Task<IActionResult> Index()
    {
        var list = await airportRepository.GetAllAsync();
        return View(mapper.Map<List<VmAirport>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
       
        return id switch
        {
            0 => View(new VmAirport()),
            _ => View(mapper.Map<VmAirport>(await airportRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    public async Task<IActionResult> AddEdit(int id, VmAirport airport)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await airportRepository.InsertAsync(mapper.Map<Airport>(airport));
                        TempData["SuccessMessage"] = $" Airport '{airport.Name}' added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Airport '{airport.Name}': {ex.Message}";
                }

                break;
            default:
                try
                {
                    if (ModelState.IsValid)
                    {
                        //await airportRepository.UpdateAsync(id, mapper.Map<Airport>(airport));
                        await airportRepository.UpdateAsync(mapper.Map<Airport>(airport));
                        TempData["SuccessMessage"] = $" Airport '{airport.Name}' update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Airport '{airport.Name}': {ex.Message}";
                }
                break;
        }
       
        return View(new VmAirport());
    }
    
    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await airportRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }

}

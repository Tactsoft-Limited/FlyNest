using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class BaggageController(IMapper mapper, IBaggageRepository baggageRepository,IFlightRepository flightRepository) : Controller
{

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await baggageRepository.GetAllAsync(x=>x.Flight);
        return View(mapper.Map<List<VmBaggage>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["FlightId"] = await flightRepository.DropdownAsync();

        return id switch
        {
            0 => View(new VmBaggage()),
            _ => View(mapper.Map<VmBaggage>(await baggageRepository.FirstOrDefaultAsync(id)))
        };
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit( VmBaggage vmBaggage)
    {
        if (vmBaggage.Id==0)
            try
            {
                if (ModelState.IsValid)
                {
                    await baggageRepository.InsertAsync(mapper.Map<Baggage>(vmBaggage));
                    TempData["SuccessMessage"] = $" Airport <b>{vmBaggage.FlightClass}</b> added successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error adding Airport <b>{vmBaggage.FlightClass}</b>: {ex.Message}";
            }
        else
            try
            {
                if (ModelState.IsValid)
                {
                    await baggageRepository.UpdateAsync(mapper.Map<Baggage>(vmBaggage));
                    TempData["SuccessMessage"] = $" Airport <b>{vmBaggage.FlightClass}</b> update successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating Airport <b>{vmBaggage.FlightClass}</b>: {ex.Message}";
            }
        ViewData["FlightId"] = await flightRepository.DropdownAsync();
        return View(vmBaggage);
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await baggageRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }

}
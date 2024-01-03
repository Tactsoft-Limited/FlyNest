using AutoMapper;
using FlyNest.Application.Repositories.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class StoppiesController(IStoppiesRepository StoppiesRepository, IMapper mapper, IAirportRepository airportRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await StoppiesRepository.GetAllAsync(x=>x.Airport);
        return View(mapper.Map<List<VmStoppies>>(list));
    }
    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["AirportId"] = airportRepository.Dropdown();

        return id switch
        {
            0 => View(new VmStoppies()),
            _ => View(mapper.Map<VmStoppies>(await StoppiesRepository.FirstOrDefaultAsync(id)))
        };
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(int id, VmStoppies stoppies)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await StoppiesRepository.InsertAsync(mapper.Map<Stoppies>(stoppies));
                        TempData["SuccessMessage"] = $" Airport '{stoppies.Duration}' added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Airport '{stoppies.Duration}': {ex.Message}";
                }

                break;
            default:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await StoppiesRepository.UpdateAsync(mapper.Map<Stoppies>(stoppies));
                        TempData["SuccessMessage"] = $" Stoppies '{stoppies.Duration}' update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Stoppies '{stoppies.Duration}': {ex.Message}";
                }
                break;
        }
        ViewData["AirportId"] = airportRepository.Dropdown();
        return View(new VmStoppies());
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await StoppiesRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

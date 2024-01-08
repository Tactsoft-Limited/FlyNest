using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class PolicyController(IPolicyRepository policyRepository, IMapper mapper,IFlightRepository flightRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await policyRepository.GetAllAsync(x => x.Flight);
        return View(mapper.Map<List<VmPolicy>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        ViewData["FlightId"] = await flightRepository.d();

        return id switch
        {
            0 => View(new VmPolicy()),
            _ => View(mapper.Map<VmPolicy>(await policyRepository.FirstOrDefaultAsync(id)))
        };
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmPolicy VmPolicy)
    {
        if (VmPolicy.Id == 0)
            try
            {
                if (ModelState.IsValid)
                {
                    await policyRepository.InsertAsync(mapper.Map<Policy>(VmPolicy));
                    TempData["SuccessMessage"] = $" Airport <b>{VmPolicy.Description}</b> added successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error adding Airport <b>{VmPolicy.Description}</b>: {ex.Message}";
            }
        else
            try
            {
                if (ModelState.IsValid)
                {
                    await policyRepository.UpdateAsync(mapper.Map<Policy>(VmPolicy));
                    TempData["SuccessMessage"] = $" Airport <b>{VmPolicy.Description}</b> update successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating Airport <b>{VmPolicy.Description}</b>: {ex.Message}";
            }
        ViewData["FlightId"] = await flightRepository.DropdownAsync();
        return View(VmPolicy);
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await policyRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
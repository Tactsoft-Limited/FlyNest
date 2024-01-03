using AutoMapper;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.Infrastructure.Interfaces.Entities;
using FlyNest.SharedKernel.Core.Collections;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class FlightController(IFlightRepository flightRepository, IMapper mapper,IAirlineRepository airlineRepository,IAirportRepository airportRepository) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await flightRepository.GetAllAsync();
        return View(mapper.Map<List<VmFlight>>(list));
    }
    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        //ViewData["StoppiId"] = stoppiesRepository.Dropdown();
       
        ViewData["AirlineId"] = airlineRepository.Dropdown();
        ViewData["StoppiId"] = airportRepository.Dropdown();

        return id switch
        {
            0 => View(new VmFlight()),
            _ => View(mapper.Map<VmFlight>(await flightRepository.FirstOrDefaultAsync(id)))
        };
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(int id, VmFlight flight)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await flightRepository.InsertAsync(mapper.Map<Flight>(flight));
                        TempData["SuccessMessage"] = $" Airport '{flight.FlightDuration}' added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Airport '{flight.FlightDuration}': {ex.Message}";
                }

                break;
            default:
                try
                {
                    if (ModelState.IsValid)
                    {
                        await flightRepository.UpdateAsync(mapper.Map<Flight>(flight));
                        TempData["SuccessMessage"] = $" Stoppies '{flight.FlightDuration}' update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Stoppies '{flight.FlightDuration}': {ex.Message}";
                }
                break;
        }
       // ViewData["AirportId"] = airportRepository.Dropdown();
        return View(new VmFlight());
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await flightRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

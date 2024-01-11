using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class BaggageController(IMapper mapper, IBaggageRepository baggageRepository) : Controller
{
    private readonly IBaggageRepository _baggageRepository = baggageRepository;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _baggageRepository.GetAllAsync();
        return View(_mapper.Map<List<VmBaggage>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmBaggage()),
            _ => View(_mapper.Map<VmBaggage>(await _baggageRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmBaggage vmBaggage)
    {
        if(vmBaggage.Id == 0)
            try
            {
                if(ModelState.IsValid)
                {
                    await _baggageRepository.InsertAsync(_mapper.Map<Baggage>(vmBaggage));
                    TempData["SuccessMessage"] = $" Airport <b>{vmBaggage.FlightClass}</b> added successfully.";
                    return RedirectToAction("Index");
                }
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Error adding Airport <b>{vmBaggage.FlightClass}</b>: {ex.Message}";
            }
        else
            try
            {
                if(ModelState.IsValid)
                {
                    await _baggageRepository.UpdateAsync(_mapper.Map<Baggage>(vmBaggage));
                    TempData["SuccessMessage"] = $" Airport <b>{vmBaggage.FlightClass}</b> update successfully.";
                    return RedirectToAction("Index");
                }
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating Airport <b>{vmBaggage.FlightClass}</b>: {ex.Message}";
            }
        return View(vmBaggage);
    }

    public async Task<IActionResult> Delete(long id)
    {
        if(id > 0)
        {
            await _baggageRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}
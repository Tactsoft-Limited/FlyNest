using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class VisaRequirementController(IVisaRequirementRepository visaRequirementRepository, IMapper mapper, ICountryRepository countryRepository) : Controller
{
    private readonly IVisaRequirementRepository _visaRequirementRepository = visaRequirementRepository;
    private readonly ICountryRepository _countryRepository = countryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var visareqList = await _visaRequirementRepository.GetAllAsync(x => x.Country);
        return View(_mapper.Map<List<VmVisaRequirement>>(visareqList));
    }

    [HttpGet]
    public async Task<IActionResult> Details(long id)
    {
        var visaRequer = await _visaRequirementRepository.FirstOrDefaultAsync(id, x => x.Country);
        return View(_mapper.Map<VmVisaRequirement>(visaRequer));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        var viewModel = new VmVisaRequirement
        {
            CountryDropdown = _countryRepository.Dropdown(),
        };
        switch (id)
        {
            case 0:
                return View(viewModel);
            default:
                var data = await _visaRequirementRepository.FirstOrDefaultAsync(id);
                var mappedViewModel = _mapper.Map<VmVisaRequirement>(data);
                mappedViewModel.CountryDropdown = viewModel.CountryDropdown;
                return View(mappedViewModel);
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmVisaRequirement viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                if (ModelState.IsValid)
                {
                    var visaRequirement = _mapper.Map<VisaRequirement>(viewModel);
                    await _visaRequirementRepository.InsertAsync(visaRequirement);
                    TempData["SuccessMessage"] = $" Item create successfully";
                    return RedirectToAction(nameof(Index));
                }
                break;

            default:
                var existing = await _visaRequirementRepository.FirstOrDefaultAsync(viewModel.Id);
                if (ModelState.IsValid)
                {
                    var visaRequirement = _mapper.Map<VisaRequirement>(viewModel);
                    await _visaRequirementRepository.UpdateAsync(existing.Id, visaRequirement);
                    TempData["SuccessMessage"] = $" Item update successfully";
                    return RedirectToAction(nameof(Index));
                }
                break;
        }

        return View(viewModel);
    }

    // GET: VmVisaRequirementController/Delete/5
    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _visaRequirementRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

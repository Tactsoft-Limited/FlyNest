using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class VisaRequirementController(IVisaRequirementRepository visaRequirementRepository, IMapper mapper) : Controller
{
    private readonly IVisaRequirementRepository _visaRequirementRepository = visaRequirementRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var visareqList = await _visaRequirementRepository.GetAllAsync(x => x.Country);
        return View(_mapper.Map<List<VmVisaRequirement>>(visareqList));
    }
}

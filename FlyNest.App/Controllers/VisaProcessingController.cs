using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers;

[AllowAnonymous]
public class VisaProcessingController(IVisaRequirementRepository visaRequirementRepository, IMapper mapper) : Controller
{
    private readonly IVisaRequirementRepository _visaRequirementRepository = visaRequirementRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var visaRequrementList = await _visaRequirementRepository.GetAllAsync(x => x.Country);
        return View(_mapper.Map<List<VmVisaRequirement>>(visaRequrementList));
    }
}

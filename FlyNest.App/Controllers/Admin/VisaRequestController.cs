using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class VisaRequestController(IVisaRequestRepository visaRequestRepository, IMapper mapper) : Controller
{
    private readonly IVisaRequestRepository _visaRequestRepository = visaRequestRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var requestList = await _visaRequestRepository.GetAllAsync();
        return View(_mapper.Map<List<VmVisaRequest>>(requestList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var request = await _visaRequestRepository.FirstOrDefaultAsync(id);
        return View(_mapper.Map<VmVisaRequest>(request));
    }
}

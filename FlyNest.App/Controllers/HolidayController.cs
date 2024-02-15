using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlyNest.App.Controllers;

[AllowAnonymous]
public class HolidayController(ITourPackageRepository packageRepository, ICountryRepository countryRepository, IMapper mapper) : Controller
{
    private readonly ITourPackageRepository _packageRepository = packageRepository;
    private readonly ICountryRepository _countryRepository = countryRepository;
    private readonly IMapper _mapper = mapper;

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult International()
    {
        var countries = _countryRepository.GetAll();
        return View(_mapper.Map<List<VmCountry>>(countries));
    }

    public IActionResult GetPackagesByCountry(long id)
    {
        var countryPackage = _packageRepository.GetAll().Include(tp => tp.Country).Where(x => x.CountryId == id).ToList();
        var res = _mapper.Map<List<VmTourPackage>>(countryPackage);
        return View(res);
    }
    public async Task<IActionResult> PackageDetails(long id)
    {
        var details = await _packageRepository.FirstOrDefaultAsync(id, x => x.Country);
        return View(_mapper.Map<VmTourPackage>(details));
    }

    public IActionResult Umrah()
    {
        var package = _packageRepository.GetAll().Where(x => x.PackageType == PackageType.Umrah).ToList();
        return View(_mapper.Map<List<VmTourPackage>>(package));
    }

    public IActionResult ExploreBD()
    {
        var package = _packageRepository.GetAll().Where(x => x.PackageType == PackageType.ExploreBD).ToList();
        return View(_mapper.Map<List<VmTourPackage>>(package));
    }
}

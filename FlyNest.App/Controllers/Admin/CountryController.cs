using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FlyNest.App.Controllers.Admin;

[AllowAnonymous] //TODO : Need to remove
public class CountryController : Controller
{
    private readonly ICountryRepository _countryRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public CountryController(ICountryRepository countryRepository, IMapper mapper, IFileStorageService fileStorageService)
    {
        _countryRepository = countryRepository;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        CommonVariables.PictureLocation = "images/countries";
    }

    // GET: CountryController
    public async Task<ActionResult> Index()
    {
        var countries = await _countryRepository.GetAllAsync();
        return View(_mapper.Map<List<VmCountry>>(countries));
    }

    // GET: CountryController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmCountry());
            default:
                var data = await _countryRepository.FirstOrDefaultAsync(id);
                return View(_mapper.Map<VmCountry>(data));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmCountry viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                if (ModelState.IsValid)
                {
                    if (viewModel.ImageFile != null)
                    {
                        viewModel.Image = await _fileStorageService.SaveImageAsync(viewModel.ImageFile);
                    }
                    var country = _mapper.Map<Country>(viewModel);
                    await _countryRepository.InsertAsync(country);
                    return RedirectToAction(nameof(Index));
                }
                break;

            default:
                var existing = await _countryRepository.FirstOrDefaultAsync(viewModel.Id);
                if (ModelState.IsValid)
                {
                    viewModel.Image = viewModel.ImageFile != null ? await _fileStorageService.UpdateImageAsync(existing.Image, viewModel.ImageFile) : existing.Image;
                    var country = _mapper.Map<Country>(viewModel);
                    await _countryRepository.UpdateAsync(existing.Id, country);
                    return RedirectToAction(nameof(Index));
                }

                break;
        }

        return View(viewModel);
    }

    // GET: CountryController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: CountryController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}

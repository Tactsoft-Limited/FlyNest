using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

[AllowAnonymous] //TODO : Need to remove
public class TourPackageController : Controller
{
    private readonly ITourPackageRepository _repository;
    private readonly ICountryRepository _countryRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public TourPackageController(ITourPackageRepository repository, IFileStorageService fileStorageService, IMapper mapper, ICountryRepository countryRepository)
    {
        CommonVariables.PictureLocation = "images/tourPackage";
        _repository = repository;
        _fileStorageService = fileStorageService;
        _mapper = mapper;
        _countryRepository = countryRepository;
    }

    public async Task<IActionResult> Index()
    {
        var packageList = await _repository.GetAllAsync(x => x.Country);
        return View(_mapper.Map<List<VmTourPackage>>(packageList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var tourPackage = await _repository.FirstOrDefaultAsync(id, x => x.Country);
        return View(_mapper.Map<VmTourPackage>(tourPackage));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        var viewModel = new VmTourPackage
        {
            CountryDropdown = _countryRepository.Dropdown(),
        };
        switch (id)
        {
            case 0:
                return View(viewModel);
            default:
                var data = await _repository.FirstOrDefaultAsync(id);
                var mappedViewModel = _mapper.Map<VmTourPackage>(data);
                mappedViewModel.CountryDropdown = viewModel.CountryDropdown;
                return View(mappedViewModel);
        }
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmTourPackage viewModel)
    {
        if (viewModel.Id == 0)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.ImageOneFile != null)
                {
                    viewModel.ImageOne = await _fileStorageService.SaveImageAsync(viewModel.ImageOneFile);
                }
                if (viewModel.ImageTwoFile != null)
                {
                    viewModel.ImageTwo = await _fileStorageService.SaveImageAsync(viewModel.ImageTwoFile);
                }
                if (viewModel.ImageThreeFile != null)
                {
                    viewModel.ImageThree = await _fileStorageService.SaveImageAsync(viewModel.ImageThreeFile);
                }
                var package = _mapper.Map<TourPackage>(viewModel);
                await _repository.InsertAsync(package);


                return RedirectToAction(nameof(Index));
            }
        }
        else if (viewModel.Id > 0)
        {
            var existing = await _repository.FirstOrDefaultAsync(viewModel.Id);
            if (ModelState.IsValid)
            {
                viewModel.ImageOne = viewModel.ImageOneFile != null ? await _fileStorageService.UpdateImageAsync(existing.ImageOne, viewModel.ImageOneFile) : existing.ImageOne;

                viewModel.ImageTwo = viewModel.ImageOneFile != null ? await _fileStorageService.UpdateImageAsync(existing.ImageTwo, viewModel.ImageTwoFile) : existing.ImageTwo;

                viewModel.ImageThree = viewModel.ImageOneFile != null ? await _fileStorageService.UpdateImageAsync(existing.ImageThree, viewModel.ImageThreeFile) : existing.ImageThree;

                var package = _mapper.Map<TourPackage>(viewModel);

                await _repository.UpdateAsync(existing.Id, package);

                return RedirectToAction(nameof(Index));

            }
        }
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            var existing = _mapper.Map<VmTourPackage>(await _repository.FirstOrDefaultAsync(id));
            new[] { existing.ImageOne, existing.ImageTwo, existing.ImageThree }
            .Where(img => img != null).ToList().ForEach(async img => await _fileStorageService.RemoveFileAsync(img));

            await _repository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }

}

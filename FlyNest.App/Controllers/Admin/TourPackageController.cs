using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

[AllowAnonymous] //TODO : Need to remove
public class TourPackageController(ITourPackageRepository repository, IMapper mapper, IFileStorageService fileStorageService) : Controller
{
    private readonly ITourPackageRepository _repository = repository;
    private readonly IFileStorageService _fileStorageService = fileStorageService;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var packageList = await _repository.GetAllAsync();
        return View(_mapper.Map<List<VmTourPackage>>(packageList));
    }

    public async Task<IActionResult> Details(long id)
    {
        var tourPackage = await _repository.FirstOrDefaultAsync(id);
        return View(_mapper.Map<VmTourPackage>(tourPackage));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmTourPackage());
            default:
                var data = await _repository.FirstOrDefaultAsync(id);
                return View(_mapper.Map<VmTourPackage>(data));
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
                viewModel.ImageOne = viewModel.ImageOneFile != null
    ? await _fileStorageService.UpdateImageAsync(existing.ImageOne, viewModel.ImageOneFile)
    : existing.ImageOne;

                viewModel.ImageTwo = viewModel.ImageOneFile != null
    ? await _fileStorageService.UpdateImageAsync(existing.ImageTwo, viewModel.ImageOneFile)
    : existing.ImageTwo;

                viewModel.ImageThree = viewModel.ImageOneFile != null
    ? await _fileStorageService.UpdateImageAsync(existing.ImageThree, viewModel.ImageOneFile)
    : existing.ImageThree;

                var package = _mapper.Map<TourPackage>(viewModel);

                await _repository.UpdateAsync(existing.Id, package);

                return RedirectToAction(nameof(Index));

            }
        }
        return View(viewModel);
    }

}

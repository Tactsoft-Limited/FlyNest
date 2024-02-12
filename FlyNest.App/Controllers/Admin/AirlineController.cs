using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class AirlineController : Controller
{
    private readonly IAirlineRepository _repository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public AirlineController(IAirlineRepository repository, IMapper mapper, IFileStorageService fileStorageService)
    {
        _repository = repository;
        _mapper = mapper;
        _fileStorageService = fileStorageService;
        CommonVariables.PictureLocation = "images/airline";
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _repository.GetAllAsync();
        return View(_mapper.Map<List<VmAirline>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmAirline()),
            _ => View(_mapper.Map<VmAirline>(await _repository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmAirline viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (viewModel.LogoFile != null)
                        {
                            viewModel.Logo = await _fileStorageService.SaveImageAsync(viewModel.LogoFile);
                        }

                        await _repository.InsertAsync(_mapper.Map<Airline>(viewModel));
                        TempData["SuccessMessage"] = $" Airline added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Airline : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _repository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {
                        viewModel.Logo = viewModel.LogoFile != null ? await _fileStorageService.UpdateImageAsync(existing.Logo, viewModel.LogoFile) : existing.Logo;

                        var airline = _mapper.Map<Airline>(viewModel);
                        await _repository.UpdateAsync(existing.Id, airline);

                        TempData["SuccessMessage"] = $" Airline update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Airline : {ex.Message}";
                }
                break;
        }

        return View(new VmAirline());
    }


    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _repository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

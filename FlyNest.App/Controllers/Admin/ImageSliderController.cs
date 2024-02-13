using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FlyNest.App.Controllers.Admin;

[AllowAnonymous] //TODO: Need to remove.
public class ImageSliderController : Controller
{
    private readonly IImageSliderRepository _imageSliderRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMapper _mapper;

    public ImageSliderController(IImageSliderRepository imageSliderRepository, IFileStorageService fileStorageService, IMapper mapper)
    {
        _imageSliderRepository = imageSliderRepository;
        _fileStorageService = fileStorageService;
        _mapper = mapper;
        CommonVariables.PictureLocation = "images/slider";
    }

    public async Task<IActionResult> Index()
    {
        var list = await _imageSliderRepository.GetAllAsync();
        return View(_mapper.Map<List<VmImageSlider>>(list));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmImageSlider()),
            _ => View(_mapper.Map<VmImageSlider>(await _imageSliderRepository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmImageSlider viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (viewModel.ImageFile != null)
                        {
                            viewModel.Image = await _fileStorageService.SaveImageAsync(viewModel.ImageFile);
                        }

                        await _imageSliderRepository.InsertAsync(_mapper.Map<ImageSlider>(viewModel));
                        TempData["SuccessMessage"] = $" Image added successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error adding Image : {ex.Message}";
                }

                break;
            default:
                try
                {
                    var existing = await _imageSliderRepository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {
                        viewModel.Image = viewModel.ImageFile != null ? await _fileStorageService.UpdateImageAsync(existing.Image, viewModel.ImageFile) : existing.Image;

                        var imageSlide = _mapper.Map<ImageSlider>(viewModel);
                        await _imageSliderRepository.UpdateAsync(existing.Id, imageSlide);

                        TempData["SuccessMessage"] = $" Image update successfully.";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    TempData["ErrorMessage"] = $"Error updating Image : {ex.Message}";
                }
                break;
        }

        return View(new VmAirline());
    }

    [HttpGet]
    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            var existing = _mapper.Map<VmImageSlider>(await _imageSliderRepository.FirstOrDefaultAsync(id));
            if (existing.Image != null)
            {
                _fileStorageService.RemoveFile(existing.Image);
            }
            await _imageSliderRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

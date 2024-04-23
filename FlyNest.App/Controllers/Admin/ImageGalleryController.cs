using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Core.FileExtentions;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace FlyNest.App.Controllers.Admin;

public class ImageGalleryController : Controller
{
    private readonly IImageGalleryRepository _repository;
    private readonly IFileStorageService _fileService;
    private readonly IMapper _mapper;

    public ImageGalleryController(IImageGalleryRepository repository, IFileStorageService fileService, IMapper mapper)
    {
        _repository = repository;
        _fileService = fileService;
        _mapper = mapper;
        CommonVariables.PictureLocation = "images/gallery";
    }

    public async Task<IActionResult> Index()
    {
        var imageList = await _repository.GetAllAsync();
        return View(_mapper.Map<List<VmImageGallery>>(imageList));
    }

    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        return id switch
        {
            0 => View(new VmImageGallery()),
            _ => View(_mapper.Map<VmImageGallery>(await _repository.FirstOrDefaultAsync(id)))
        };
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(long id, VmImageGallery viewModel)
    {
        switch (id)
        {
            case 0:
                try
                {
                    if (ModelState.IsValid)
                    {
                        viewModel.ImageUrl = viewModel.ImageUrlFile != null ? await _fileService.SaveImageAsync(viewModel.ImageUrlFile) : null;

                        await _repository.InsertAsync(_mapper.Map<ImageGallery>(viewModel));
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
                    var existing = await _repository.FirstOrDefaultAsync(viewModel.Id);
                    if (ModelState.IsValid)
                    {
                        viewModel.ImageUrl = viewModel.ImageUrlFile != null ? await _fileService.UpdateImageAsync(existing.ImageUrl, viewModel.ImageUrlFile) : existing.ImageUrl;

                        var imageGallery = _mapper.Map<ImageGallery>(viewModel);
                        await _repository.UpdateAsync(existing.Id, imageGallery);

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

        return View(new VmImageGallery());
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

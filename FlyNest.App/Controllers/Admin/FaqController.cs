using AutoMapper;
using FlyNest.Application.Interfaces.Entities;
using FlyNest.Application.Repositories.Entities;
using FlyNest.Application.ViewModels.VmEntities;
using FlyNest.SharedKernel.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlyNest.App.Controllers.Admin;

public class FaqController(IFaqRepository faqRepository, IMapper mapper) : Controller
{
    private readonly IFaqRepository _faqRepository = faqRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IActionResult> Index()
    {
        var faqList = await _faqRepository.GetAllAsync();
        return View(_mapper.Map<List<VmFaq>>(faqList));
    }

    // GET: CountryController/Details/5
    public async Task<ActionResult> Details(int id)
    {
        var faq = await _faqRepository.FirstOrDefaultAsync(id);
        return View(_mapper.Map<VmFaq>(faq));
    }


    [HttpGet]
    public async Task<IActionResult> AddEdit(long id)
    {
        switch (id)
        {
            case 0:
                return View(new VmFaq());
            default:
                var data = await _faqRepository.FirstOrDefaultAsync(id);
                return View(_mapper.Map<VmFaq>(data));
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddEdit(VmFaq viewModel)
    {
        switch (viewModel.Id)
        {
            case 0:
                if (ModelState.IsValid)
                {

                    var faq = _mapper.Map<Faq>(viewModel);
                    await _faqRepository.InsertAsync(faq);
                    TempData["SuccessMessage"] = $" Item create successfully";
                    return RedirectToAction(nameof(Index));
                }
                break;

            default:
                var existing = await _faqRepository.FirstOrDefaultAsync(viewModel.Id);
                if (ModelState.IsValid)
                {
                    var faq = _mapper.Map<Faq>(viewModel);
                    await _faqRepository.UpdateAsync(existing.Id, faq);
                    TempData["SuccessMessage"] = $" Item update successfully";
                    return RedirectToAction(nameof(Index));
                }
                break;
        }

        return View(viewModel);
    }

    // GET: FaqController/Delete/5
    public async Task<IActionResult> Delete(long id)
    {
        if (id > 0)
        {
            await _faqRepository.DeleteAsync(id);
            TempData["SuccessMessage"] = $" Item remove successfully";
            return RedirectToAction("Index");
        }
        TempData["ErrorMessage"] = $"Error delete : Item not found";
        return RedirectToAction("Index");
    }
}

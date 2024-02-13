using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmImageSlider : BaseEntity
{
    [Display(Name = "Slide Title")]
    public string Title { get; set; }
    [Display(Name = "Slide Sub-Title")]
    public string SubTitle { get; set; }
    public int Priority { get; set; }
    public bool IsActive { get; set; }
    [Display(Name = "Picture")]
    public string Image { get; set; }

    [Display(Name = "Upload Inage")]
    public IFormFile ImageFile { get; set; }
}

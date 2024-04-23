using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmImageGallery : BaseEntity
{
    [Display(Name = "Event Title")]
    public string EventTitle { get; set; }

    [Display(Name = "Event Date")]
    [DataType(DataType.Date)]
    public DateTime EventDate { get; set; } = DateTime.Now;

    [Display(Name = "Image")]
    public string ImageUrl { get; set; }

    public IFormFile ImageUrlFile { get; set; }
}

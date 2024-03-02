using FlyNest.SharedKernel.Core.CustomValidation;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmCountry : BaseEntity
{
    [Required(ErrorMessage = "Country name is required.")]
    [Display(Name = "Country Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Capital name is required.")]
    [Display(Name = "Capital Name")]
    public string CapitalCity { get; set; }

    [Required(ErrorMessage = "Local time is required.")]
    [Display(Name = "Local Time")]
    public string LocalTime { get; set; }

    [Required(ErrorMessage = "Telephone code is required.")]
    [Display(Name = "Telephone Code")]
    public string TelephoneCode { get; set; }

    [Required(ErrorMessage = "Bank time is required.")]
    [Display(Name = "Bank Time")]
    public string BankTime { get; set; }

    [Required(ErrorMessage = "Embassy address is required.")]
    [Display(Name = "Embassy Address")]
    public string EmbassyAddress { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [Display(Name = "Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Language name is required.")]
    [Display(Name = "Language")]
    public string Language { get; set; }

    [Required(ErrorMessage = "Currency is required.")]
    [Display(Name = "Currency")]
    public string Currency { get; set; }

    [Required(ErrorMessage = "Tourism place is required.")]
    [Display(Name = "Tourism Place")]
    public string TourismPlace { get; set; }

    public string Image { get; set; }

    [ImageFileValidation(minFileSize: 200 * 1024, maxFileSize: 2 * 1024 * 1024, minWidth: 1200, maxWidth: 1500, minHeight: 800, maxHeight: 1000)]
    [Display(Name = "Choose Image")]
    public IFormFile ImageFile { get; set; }
}

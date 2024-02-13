using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmTourPackage : BaseEntity
{
    [Required]
    [Display(Name = "Title")]
    public string Title { get; set; }
    [Display(Name = "Tour Description")]
    public string TourDescription { get; set; }
    public string Description { get; set; }
    public string HotelDetails { get; set; }
    public string Inclusion { get; set; }
    public string Exclusion { get; set; }
    public double PackagePrice { get; set; }
    public long CountryId { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; }
    public PackageType PackageType { get; set; }

    public string ImageOne { get; set; }
    public IFormFile ImageOneFile { get; set; }
    public string ImageTwo { get; set; }
    public IFormFile ImageTwoFile { get; set; }
    public string ImageThree { get; set; }
    public IFormFile ImageThreeFile { get; set; }

    public IEnumerable<SelectListItem> CountryDropdown { get; set; } = new List<SelectListItem>();

}

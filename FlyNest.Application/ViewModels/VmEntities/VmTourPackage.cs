using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmTourPackage : BaseEntity
{
    [Required]
    [Display(Name = "")]
    public string Title { get; set; }
    public string TourDescription { get; set; }
    public string Description { get; set; }
    public string HotelDetails { get; set; }
    public string Inclusion { get; set; }
    public string Exclusion { get; set; }
    public double PackagePrice { get; set; }
    public string Countries { get; set; }
    public PackageType PackageType { get; set; }

    public string ImageOne { get; set; }
    public string ImageTwo { get; set; }
    public string ImageThree { get; set; }
}

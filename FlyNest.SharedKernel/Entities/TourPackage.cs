using FlyNest.SharedKernel.Core.Default;
using FlyNest.SharedKernel.Entities.BaseEntities;

namespace FlyNest.SharedKernel.Entities;

public class TourPackage : AuditableEntity
{
    public string Title { get; set; }
    public string TourDescription { get; set; }
    public string Description { get; set; }
    public string HotelDetails { get; set; }
    public string Inclusion { get; set; }
    public string Exclusion { get; set; }
    public double PackagePrice { get; set; }
    public long? CountryId { get; set; }
    public Country Country { get; set; }
    public PackageType PackageType { get; set; }
    public string ImageOne { get; set; }
    public string ImageTwo { get; set; }
    public string ImageThree { get; set; }
}


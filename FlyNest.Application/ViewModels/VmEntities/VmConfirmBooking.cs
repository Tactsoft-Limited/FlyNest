using FlyNest.SharedKernel.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmConfirmBooking : BaseEntity
{
    public long TourPackageId { get; set; }
    public double PackagePrice { get; set; }

    [Display(Name = ("Package Title"))]
    public string PackageTitle { get; set; }

    [Display(Name = ("Transaction ID"))]
    public string TransactionId { get; set; } = Guid.NewGuid().ToString("N").ToUpper()[..12];

    [Required(ErrorMessage = ("Person Must be greater than 0"))]
    [Display(Name = ("Total Person"))]
    public int TotalPerson { get; set; } = 1;

    [Display(Name = ("Total Amount"))]
    public double TotalAmount { get; set; }

    [Display(Name = ("Full Name"))]
    [Required(ErrorMessage = ("Enter your full name. It's required."))]
    public string ClientName { get; set; }

    [Display(Name = ("Travel Date"))]
    [Required(ErrorMessage = ("Enter your travel date. It's required."))]
    [DataType(DataType.Date)]
    public DateTime TravelDate { get; set; } = DateTime.Now;

    [Display(Name = ("Email "))]
    public string ClientEmail { get; set; }

    [Display(Name = ("Mobile "))]
    [Required(ErrorMessage = ("Enter your mobile number. It's required."))]
    public string ClientPhone { get; set; }

    [Display(Name = ("Payment Method"))]
    public string PaymentMethod { get; set; }

    public string PaymentStatus { get; set; } = "pending";

    public bool TramAndCondition { get; set; }

}

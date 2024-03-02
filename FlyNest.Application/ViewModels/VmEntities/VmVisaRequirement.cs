using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmVisaRequirement : BaseEntity
{
    public long CountryId { get; set; }
    [Display(Name = "Country")]
    public string CountryName { get; set; }
    [Display(Name = "Basic Document")]
    public string BasicDocument { get; set; }
    [Display(Name = "For Business Person")]
    public string ForBusinessPerson { get; set; }
    [Display(Name = "For JobHolder")]
    public string ForJobHolder { get; set; }
    [Display(Name = "For Student")]
    public string ForStudent { get; set; }
    [Display(Name = "For Medical")]
    public string ForMedical { get; set; }
    [Display(Name = "Fees")]
    public string VisaFee { get; set; }
    [Display(Name = "Others Document")]
    public string Others { get; set; }
}

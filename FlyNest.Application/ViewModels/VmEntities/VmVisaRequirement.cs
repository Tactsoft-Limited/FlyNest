using FlyNest.SharedKernel.Entities;
using FlyNest.SharedKernel.Entities.BaseEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FlyNest.Application.ViewModels.VmEntities;

public class VmVisaRequirement : BaseEntity
{
    public string Title { get; set; }

    [Display(Name = "Country")]
    public long CountryId { get; set; }
    public VmCountry Country { get; set; }

    [Display(Name = "Country Name")]
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

    [Display(Name = "Max Stay")]
    public string MaxStay { get; set; }

    [Display(Name = "Validity")]
    public string Validity { get; set; }

    [Display(Name = "Fees")]
    public string VisaFee { get; set; }

    [Display(Name = "Others Document")]
    public string Others { get; set; }

    public IEnumerable<SelectListItem> CountryDropdown { get; set; } = new List<SelectListItem>();
}
